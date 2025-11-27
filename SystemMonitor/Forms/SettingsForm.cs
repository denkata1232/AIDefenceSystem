using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemMonitor.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SystemMonitor.Forms
{
    public partial class SettingsForm : Form
    {
        private AppSettings settings;
        private Timer screenshotTimer = new Timer();

        public SettingsForm()
        {
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
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            settings.MonitoringEnabled = chkMonitoring.Checked;
            settings.ScreenshotLogging = chkScreenshots.Checked;
            settings.NetworkMonitoring = chkNetwork.Checked;
            settings.AlertVolume = trackVolume.Value;
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
                screenshotTimer.Stop();
            }
        }
        private void Start_timer()
        {
            screenshotTimer.Interval = nudSeconds.Value*1000;
            screenshotTimer.Tick += Take_Screeenshots;
            screenshotTimer.Start();
        }
        private void Take_Screeenshots(object sender, EventArgs e)
        {
            string filename = $"screenshot_{DateTime.Now:yyyy.MM.dd_HH.mm.ss}.png";

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(filename);
        }
    }
}
