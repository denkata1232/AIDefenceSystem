namespace SystemMonitor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TextBox txtLog;
        private Label lblCpuLoad;
        private Button btnCPUTest;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.Label lblNetUp;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Label lblNetDown;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ListView processList;
        private System.Windows.Forms.Label lblThreatScore;
        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            refreshTimer = new System.Windows.Forms.Timer(components);
            lblCpu = new Label();
            lblRam = new Label();
            lblNetUp = new Label();
            lblNetDown = new Label();
            processList = new ListView();
            txtLogs = new TextBox();
            btnScan = new Button();
            btnSettings = new Button();
            lblThreatScore = new Label();
            btnCPUTest = new Button();
            lblCpuLoad = new Label();
            txtLog = new TextBox();
            SuspendLayout();
            // 
            // refreshTimer
            // 
            refreshTimer.Interval = 1000;
            refreshTimer.Tick += refreshTimer_Tick;
            // 
            // lblCpu
            // 
            lblCpu.AutoSize = true;
            lblCpu.BackColor = Color.Transparent;
            lblCpu.ForeColor = Color.Snow;
            lblCpu.Location = new Point(10, 10);
            lblCpu.Name = "lblCpu";
            lblCpu.Size = new Size(101, 15);
            lblCpu.TabIndex = 0;
            lblCpu.Text = "CPU (процесор): ";
            // 
            // lblRam
            // 
            lblRam.AutoSize = true;
            lblRam.BackColor = Color.Transparent;
            lblRam.ForeColor = Color.Snow;
            lblRam.Location = new Point(10, 35);
            lblRam.Name = "lblRam";
            lblRam.Size = new Size(110, 15);
            lblRam.TabIndex = 1;
            lblRam.Text = "RAM (Кеш памет): ";
            // 
            // lblNetUp
            // 
            lblNetUp.AutoSize = true;
            lblNetUp.BackColor = Color.Transparent;
            lblNetUp.ForeColor = Color.Snow;
            lblNetUp.Location = new Point(10, 60);
            lblNetUp.Name = "lblNetUp";
            lblNetUp.Size = new Size(106, 15);
            lblNetUp.TabIndex = 2;
            lblNetUp.Text = "Upload (качване): ";
            // 
            // lblNetDown
            // 
            lblNetDown.AutoSize = true;
            lblNetDown.BackColor = Color.Transparent;
            lblNetDown.ForeColor = Color.Snow;
            lblNetDown.Location = new Point(10, 85);
            lblNetDown.Name = "lblNetDown";
            lblNetDown.Size = new Size(122, 15);
            lblNetDown.TabIndex = 3;
            lblNetDown.Text = "Download (сваляне): ";
            // 
            // processList
            // 
            processList.BackgroundImage = Properties.Resources.Background1;
            processList.BackgroundImageTiled = true;
            processList.BorderStyle = BorderStyle.None;
            processList.ForeColor = Color.Snow;
            processList.Location = new Point(10, 138);
            processList.Name = "processList";
            processList.Size = new Size(551, 382);
            processList.TabIndex = 4;
            processList.UseCompatibleStateImageBehavior = false;
            processList.View = View.Details;
            // 
            // txtLogs
            // 
            txtLogs.BackColor = Color.FromArgb(0, 27, 56);
            txtLogs.ForeColor = Color.White;
            txtLogs.Location = new Point(567, 10);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(400, 510);
            txtLogs.TabIndex = 5;
            // 
            // btnScan
            // 
            btnScan.BackgroundImage = Properties.Resources.Background1;
            btnScan.FlatStyle = FlatStyle.Flat;
            btnScan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnScan.ForeColor = Color.Snow;
            btnScan.Location = new Point(10, 530);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(200, 30);
            btnScan.TabIndex = 6;
            btnScan.Text = "Скенер за защита";
            btnScan.Click += btnScan_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackgroundImage = Properties.Resources.Background1;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSettings.ForeColor = Color.Snow;
            btnSettings.Location = new Point(220, 530);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(131, 30);
            btnSettings.TabIndex = 0;
            btnSettings.Text = "Настройки";
            btnSettings.Click += btnSettings_Click;
            // 
            // lblThreatScore
            // 
            lblThreatScore.BackColor = Color.Transparent;
            lblThreatScore.Location = new Point(10, 112);
            lblThreatScore.Name = "lblThreatScore";
            lblThreatScore.Size = new Size(242, 23);
            lblThreatScore.TabIndex = 7;
            // 
            // btnCPUTest
            // 
            btnCPUTest.BackgroundImage = Properties.Resources.Background1;
            btnCPUTest.FlatStyle = FlatStyle.Flat;
            btnCPUTest.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCPUTest.ForeColor = Color.Snow;
            btnCPUTest.Location = new Point(357, 530);
            btnCPUTest.Name = "btnCPUTest";
            btnCPUTest.Size = new Size(204, 30);
            btnCPUTest.TabIndex = 8;
            btnCPUTest.Text = "Тест на процесора";
            btnCPUTest.Click += btnCPUTest_Click;
            // 
            // lblCpuLoad
            // 
            lblCpuLoad.BackColor = Color.Transparent;
            lblCpuLoad.ForeColor = Color.Snow;
            lblCpuLoad.Location = new Point(150, 10);
            lblCpuLoad.Name = "lblCpuLoad";
            lblCpuLoad.Size = new Size(150, 15);
            lblCpuLoad.TabIndex = 9;
            lblCpuLoad.Text = "CPU Натоварване: 0%";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(567, 530);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(400, 30);
            txtLog.TabIndex = 10;
            // 
            // MainForm
            // 
            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(979, 570);
            Controls.Add(btnCPUTest);
            Controls.Add(lblThreatScore);
            Controls.Add(btnSettings);
            Controls.Add(lblCpu);
            Controls.Add(lblRam);
            Controls.Add(lblNetUp);
            Controls.Add(lblNetDown);
            Controls.Add(processList);
            Controls.Add(txtLogs);
            Controls.Add(btnScan);
            Controls.Add(lblCpuLoad);
            Controls.Add(txtLog);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Системно наблюдение";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

    }
}
