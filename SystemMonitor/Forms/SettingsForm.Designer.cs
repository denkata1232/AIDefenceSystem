namespace SystemMonitor.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.CheckBox chkMonitoring;
        private System.Windows.Forms.CheckBox chkScreenshots;
        private System.Windows.Forms.CheckBox chkNetwork;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.Button btnSave;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chkMonitoring = new CheckBox();
            chkScreenshots = new CheckBox();
            chkNetwork = new CheckBox();
            trackVolume = new TrackBar();
            cmbTheme = new ComboBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)trackVolume).BeginInit();
            SuspendLayout();
            // 
            // chkMonitoring
            // 
            chkMonitoring.AutoSize = true;
            chkMonitoring.Location = new Point(20, 20);
            chkMonitoring.Name = "chkMonitoring";
            chkMonitoring.Size = new Size(154, 24);
            chkMonitoring.TabIndex = 0;
            chkMonitoring.Text = "Enable Monitoring";
            // 
            // chkScreenshots
            // 
            chkScreenshots.AutoSize = true;
            chkScreenshots.Location = new Point(20, 50);
            chkScreenshots.Name = "chkScreenshots";
            chkScreenshots.Size = new Size(211, 24);
            chkScreenshots.TabIndex = 1;
            chkScreenshots.Text = "Enable Screenshot Logging";
            // 
            // chkNetwork
            // 
            chkNetwork.AutoSize = true;
            chkNetwork.Location = new Point(20, 80);
            chkNetwork.Name = "chkNetwork";
            chkNetwork.Size = new Size(214, 24);
            chkNetwork.TabIndex = 2;
            chkNetwork.Text = "Enable Network Monitoring";
            // 
            // trackVolume
            // 
            trackVolume.Location = new Point(20, 120);
            trackVolume.Maximum = 100;
            trackVolume.Name = "trackVolume";
            trackVolume.Size = new Size(104, 56);
            trackVolume.TabIndex = 3;
            trackVolume.TickFrequency = 10;
            // 
            // cmbTheme
            // 
            cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTheme.Items.AddRange(new object[] { "Dark", "Light" });
            cmbTheme.Location = new Point(20, 170);
            cmbTheme.Name = "cmbTheme";
            cmbTheme.Size = new Size(121, 28);
            cmbTheme.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(20, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save Settings";
            // 
            // SettingsForm
            // 
            ClientSize = new Size(300, 280);
            Controls.Add(chkMonitoring);
            Controls.Add(chkScreenshots);
            Controls.Add(chkNetwork);
            Controls.Add(trackVolume);
            Controls.Add(cmbTheme);
            Controls.Add(btnSave);
            Name = "SettingsForm";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)trackVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}