using SystemMonitor.Core;
using SystemMonitor.Core.MonitorFunc;

namespace SystemMonitor.Forms
{
    public partial class SettingsForm : Form
    {
        private AppSettings settings;
        public MainForm mainForm;

        public SettingsForm(MainForm main)
        {
            mainForm = main;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            settings = SettingsManager.Load();

            chkMonitoring.Checked = settings.MonitoringEnabled;
            chkScreenshots.Checked = settings.ScreenshotLogging;
            chkNetwork.Checked = settings.NetworkMonitoring;
            trackVolume.Value = settings.AlertVolume;
            cmbTheme.SelectedItem = settings.Theme;
            nudSeconds.Value = settings.ScreenshotTimer;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            settings.MonitoringEnabled = chkMonitoring.Checked;
            settings.ScreenshotLogging = chkScreenshots.Checked;
            settings.NetworkMonitoring = chkNetwork.Checked;
            settings.AlertVolume = trackVolume.Value;
            settings.ScreenshotTimer = (int)nudSeconds.Value;
            settings.Theme = cmbTheme.SelectedItem?.ToString() ?? "Dark";

            SettingsManager.Save(settings);

            MessageBox.Show("Settings saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            Close();
        }

        private void chkScreenshots_CheckedChanged(object sender, EventArgs e)
        {
            if (chkScreenshots.Checked)
            {
                Start_timer();
                lblSeconds.Visible = true;
                nudSeconds.Visible = true;
            }
            else
            {
                MainForm.screenshotTimer.Stop();
                lblSeconds.Visible = false;
                nudSeconds.Visible = false;
            }
        }
        private void Start_timer()
        {
            MainForm.screenshotTimer.Interval = (int)nudSeconds.Value * 1000;
            MainForm.screenshotTimer.Tick += Take_Screeenshots;
            MainForm.screenshotTimer.Start();
        }
        private void Take_Screeenshots(object sender, EventArgs e)
        {

            if (chkScreenshots.Checked)
            {
                string filename = $"screenshot_{DateTime.Now:yyyy.MM.dd_HH.mm.ss}.png";

                Bitmap bmp = ScreenshotTaker.PrintWindow(mainForm.Handle); // mainForm.Handle -> app to screenshot
                Directory.CreateDirectory("Screenshots");
                bmp.Save($"Screenshots\\{filename}");
            }
        }

        private void nudSeconds_ValueChanged(object sender, EventArgs e)
        {

            Start_timer();
        }
    }
}
