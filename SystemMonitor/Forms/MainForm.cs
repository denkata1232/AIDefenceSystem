using InputSimulatorStandard;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Net.NetworkInformation;
using SystemMonitor.Core;
using SystemMonitor.Core.Data;
using SystemMonitor.Core.PCTesters;
using SystemMonitor.Forms;

namespace SystemMonitor
{
    public partial class MainForm : Form
    {
        public static System.Windows.Forms.Timer screenshotTimer = new System.Windows.Forms.Timer();
        private long lastBytesSent = 0;
        private long lastBytesReceived = 0;
        private TelemetryService telemetry;
        private AdvancedCpuTester cpuTester;
        private PerformanceCounter cpuCounter;
        private bool cpuTesterRunning = false;
        private NetworkInterface activeNetwork;
        private AlertManager alertManager = new AlertManager();



        public MainForm()
        {
            InitializeComponent();
            //LoadBackground();

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            activeNetwork = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(i => i.OperationalStatus == OperationalStatus.Up);

            if (activeNetwork != null)
            {
                var stats = activeNetwork.GetIPv4Statistics();
                lastBytesSent = stats.BytesSent;
                lastBytesReceived = stats.BytesReceived;
            }

            cpuTester = new AdvancedCpuTester();

            // Bind UI updates
            cpuTester.OnCpuUpdated = (cpu) =>
            {
                SafeUI(() =>
                {
                    lblCpu.Text = $"CPU (процесор): {cpu:0.0}%";
                });
            };

            cpuTester.OnStatusChanged = (msg) =>
            {
                SafeUI(() =>
                {
                    txtLogs.AppendText(msg + Environment.NewLine);
                });
            };

        }

        private void LoadBackground()
        {
            PictureBox backgroundGif = new PictureBox();
            backgroundGif.Dock = DockStyle.Fill;
            backgroundGif.SizeMode = PictureBoxSizeMode.StretchImage;
            backgroundGif.Image = Image.FromFile("BackgroundMainform.gif");
            this.Controls.Add(backgroundGif);
            backgroundGif.SendToBack();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            telemetry = new TelemetryService();
            telemetry.Start();
            telemetry.OnThreatScoreUpdated += UpdateThreatScoreUI;
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateCpu();
            UpdateRam();
            UpdateNetwork();
            UpdateProcessList();
            RefreshLogs();
        }

        private void UpdateThreatScoreUI(int score, string status)
        {

            SafeUI(() =>
            {
                lblThreatScore.Text = $"Оценка на защитата: {score} ({status})";

                if (score < 20) lblThreatScore.BackColor = Color.Green;
                else if (score < 50) lblThreatScore.BackColor = Color.Yellow;
                else if (score < 75) lblThreatScore.BackColor = Color.Orange;
                else lblThreatScore.BackColor = Color.Red;
            });

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            var processes = Process.GetProcesses();
            int suspiciousCount = 0;

            // Fake rules for demo (to replace with AI)
            foreach (var p in processes)
            {
                if (p.ProcessName.Contains("cmd") ||
                    p.ProcessName.Contains("powershell") ||
                    p.ProcessName.Contains("unknown"))
                {
                    suspiciousCount++;
                }
            }

            string result =
                $"Ръчно сканиране завършено{Environment.NewLine}" +
                $"Брой процеси: {processes.Length}{Environment.NewLine}" +
                $"Подозрителни процеси: {suspiciousCount}{Environment.NewLine}" +
                $"Наблюдение на мрежата: {(SettingsManager.Load().NetworkMonitoring ? "Да" : "Не")}{Environment.NewLine}" +
                $"Регистриране на екранни снимки: {(SettingsManager.Load().ScreenshotLogging ? "Да" : "Не")}{Environment.NewLine}" +
                $"Пълен статус: {(suspiciousCount > 0 ? "Потенциални проблеми" : "Чиста система")}";

            new ScanResult(result).Show();
        }

        private void UpdateCpu()
        {
            float cpu = cpuCounter.NextValue();
            lblCpu.Text = $"CPU (процесор): {cpu:0.0}%";
            alertManager.CheckCpu(cpu);
        }

        private void UpdateRam()
        {
            var ci = new ComputerInfo();
            ulong total = ci.TotalPhysicalMemory;
            ulong available = ci.AvailablePhysicalMemory;
            ulong used = total - available;

            double usedGB = used / 1024.0 / 1024 / 1024;
            double totalGB = total / 1024.0 / 1024 / 1024;

            double percent = (double)used / total * 100.0;
            alertManager.CheckRam((float)percent);

            lblRam.Text = $"RAM (Кеш памет): {usedGB:0.00} / {totalGB:0.00} GB ({percent:0}%)";
        }

        private void UpdateNetwork()
        {
            if (activeNetwork == null)
                return;

            var stats = activeNetwork.GetIPv4Statistics();
            long sent = stats.BytesSent;
            long recv = stats.BytesReceived;

            long sentDiff = sent - lastBytesSent;
            long recvDiff = recv - lastBytesReceived;

            lastBytesSent = sent;
            lastBytesReceived = recv;

            alertManager.CheckNetwork(sentDiff / 1024.0, recvDiff / 1024.0);

            lblNetUp.Text = $"Upload (качване): {sentDiff / 1024.0:0.0} KB/s";
            lblNetDown.Text = $"Download (сваляне): {recvDiff / 1024.0:0.0} KB/s";
        }

        private void UpdateProcessList()
        {
            processList.Items.Clear();

            var processes = Process.GetProcesses()
                .OrderByDescending(p => p.WorkingSet64)
                .Take(50); // display top 50

            foreach (var p in processes)
            {
                try
                {
                    double memMB = p.WorkingSet64 / 1024.0 / 1024;

                    var item = new ListViewItem(new string[]
                    {
                        p.ProcessName,
                        memMB.ToString("0.0"),
                        p.Id.ToString()
                    });

                    processList.Items.Add(item);
                }
                catch
                {
                    
                }
            }
            alertManager.CheckNewProcesses(Process.GetProcesses());
        }

        private void RefreshLogs()
        {
            if (File.Exists("system_logs.txt"))
            {
                txtLogs.Text = File.ReadAllText("system_logs.txt");
                txtLogs.SelectionStart = txtLogs.Text.Length;
                txtLogs.ScrollToCaret();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm(this).ShowDialog();
        }

        private void SafeUI(Action uiAction)
        {
            if (InvokeRequired)
                Invoke(uiAction);
            else
                uiAction();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            telemetry.Stop();
        }

        private void btnCPUTest_Click(object sender, EventArgs e)
        {
            if (cpuTesterRunning == false)
            {
                cpuTesterRunning = true;
                btnCPUTest.Text = "Спри CPU тест";
                cpuTester.Start(100);  // full stress
            }
            else
            {
                cpuTesterRunning = false;
                btnCPUTest.Text = "Тест на процесора";
                cpuTester.Stop();
            }
        }

        public static void ScreenShotAction()
        {
            var simulator = new InputSimulator();
        }
    }
}
