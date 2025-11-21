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

namespace SystemMonitor.Forms
{
    public partial class SettingsForm : Form
    {
        private AppSettings settings;

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
    }
}
