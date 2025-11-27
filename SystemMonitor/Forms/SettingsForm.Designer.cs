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
            nudSeconds = new NumericUpDown();
            lblSeconds = new Label();
            ((System.ComponentModel.ISupportInitialize)trackVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSeconds).BeginInit();
            SuspendLayout();
            // 
            // chkMonitoring
            // 
            chkMonitoring.AutoSize = true;
            chkMonitoring.Location = new Point(20, 20);
            chkMonitoring.Name = "chkMonitoring";
            chkMonitoring.Size = new Size(191, 19);
            chkMonitoring.TabIndex = 0;
            chkMonitoring.Text = "Активиране на наблюдението";
            // 
            // chkScreenshots
            // 
            chkScreenshots.AutoSize = true;
            chkScreenshots.Location = new Point(20, 50);
            chkScreenshots.Name = "chkScreenshots";
            chkScreenshots.Size = new Size(201, 19);
            chkScreenshots.TabIndex = 1;
            chkScreenshots.Text = "Активиране на екранни снимки";
            chkScreenshots.CheckedChanged += chkScreenshots_CheckedChanged;
            // 
            // chkNetwork
            // 
            chkNetwork.AutoSize = true;
            chkNetwork.Location = new Point(20, 80);
            chkNetwork.Name = "chkNetwork";
            chkNetwork.Size = new Size(247, 19);
            chkNetwork.TabIndex = 2;
            chkNetwork.Text = "Активирайте наблюдението на мрежата";
            // 
            // trackVolume
            // 
            trackVolume.Location = new Point(20, 120);
            trackVolume.Maximum = 100;
            trackVolume.Name = "trackVolume";
            trackVolume.Size = new Size(104, 45);
            trackVolume.TabIndex = 3;
            trackVolume.TickFrequency = 10;
            // 
            // cmbTheme
            // 
            cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTheme.Items.AddRange(new object[] { "Dark", "Light" });
            cmbTheme.Location = new Point(20, 170);
            cmbTheme.Name = "cmbTheme";
            cmbTheme.Size = new Size(121, 23);
            cmbTheme.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(20, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(121, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "Запази настройки";
            btnSave.Click += BtnSave_Click;
            // 
            // nudSeconds
            // 
            nudSeconds.Location = new Point(312, 46);
            nudSeconds.Name = "nudSeconds";
            nudSeconds.Size = new Size(75, 23);
            nudSeconds.TabIndex = 6;
            nudSeconds.Value = new decimal(new int[] { 10, 0, 0, 0 });
            nudSeconds.Visible = false;
            nudSeconds.ValueChanged += nudSeconds_ValueChanged;
            // 
            // lblSeconds
            // 
            lblSeconds.AutoSize = true;
            lblSeconds.Location = new Point(282, 28);
            lblSeconds.Name = "lblSeconds";
            lblSeconds.Size = new Size(114, 15);
            lblSeconds.TabIndex = 7;
            lblSeconds.Text = "интервал в секунди";
            lblSeconds.Visible = false;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(408, 280);
            Controls.Add(lblSeconds);
            Controls.Add(nudSeconds);
            Controls.Add(chkMonitoring);
            Controls.Add(chkScreenshots);
            Controls.Add(chkNetwork);
            Controls.Add(trackVolume);
            Controls.Add(cmbTheme);
            Controls.Add(btnSave);
            Name = "SettingsForm";
            Text = "Настройки";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)trackVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSeconds).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudSeconds;
        private Label lblSeconds;
    }
}