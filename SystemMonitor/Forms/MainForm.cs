using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Net.NetworkInformation;
using SystemMonitor.Core;
using SystemMonitor.Core.Data;
using SystemMonitor.Forms;

namespace SystemMonitor
{
    public partial class MainForm : Form
    {
        private long lastBytesSent = 0;
        private long lastBytesReceived = 0;
        private TelemetryService telemetry;
        private PerformanceCounter cpuCounter;
        private NetworkInterface activeNetwork;
        private AlertManager alertManager = new AlertManager();

        

        public MainForm()
        {
            InitializeComponent();

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            activeNetwork = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(i => i.OperationalStatus == OperationalStatus.Up);

            if (activeNetwork != null)
            {
                var stats = activeNetwork.GetIPv4Statistics();
                lastBytesSent = stats.BytesSent;
                lastBytesReceived = stats.BytesReceived;
            }
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
            lblThreatScore.Text = $"Security Score: {score} ({status})";

            if (score < 20) lblThreatScore.BackColor = Color.Green;
            else if (score < 50) lblThreatScore.BackColor = Color.Yellow;
            else if (score < 75) lblThreatScore.BackColor = Color.Orange;
            else lblThreatScore.BackColor = Color.Red;
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
                $"Manual Security Scan Completed{Environment.NewLine}" +
                $"Total Processes: {processes.Length}{Environment.NewLine}" +
                $"Suspicious Processes: {suspiciousCount}{Environment.NewLine}" +
                $"Network Monitoring: {(SettingsManager.Load().NetworkMonitoring ? "ON" : "OFF")}{Environment.NewLine}" +
                $"Screenshot Logging: {(SettingsManager.Load().ScreenshotLogging ? "ON" : "OFF")}{Environment.NewLine}" +
                $"Overall Status: {(suspiciousCount > 0 ? "Potential Issues" : "System Clean")}";

            new ScanResult(result).Show();
        }

        private void UpdateCpu()
        {
            float cpu = cpuCounter.NextValue();
            lblCpu.Text = $"CPU: {cpu:0.0}%";
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

            lblRam.Text = $"RAM: {usedGB:0.00} / {totalGB:0.00} GB ({percent:0}%)";
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

            lblNetUp.Text = $"Upload: {sentDiff / 1024.0:0.0} KB/s";
            lblNetDown.Text = $"Download: {recvDiff / 1024.0:0.0} KB/s";
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
                    // some processes cannot be accessed
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
            new SettingsForm().ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            telemetry.Stop();
        }
    }
}
