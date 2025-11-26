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
            lblCpu.Location = new Point(10, 10);
            lblCpu.Name = "lblCpu";
            lblCpu.Size = new Size(101, 15);
            lblCpu.TabIndex = 0;
            lblCpu.Text = "CPU (процесор): ";
            // 
            // lblRam
            // 
            lblRam.AutoSize = true;
            lblRam.Location = new Point(10, 35);
            lblRam.Name = "lblRam";
            lblRam.Size = new Size(110, 15);
            lblRam.TabIndex = 1;
            lblRam.Text = "RAM (Кеш памет): ";
            // 
            // lblNetUp
            // 
            lblNetUp.AutoSize = true;
            lblNetUp.Location = new Point(10, 60);
            lblNetUp.Name = "lblNetUp";
            lblNetUp.Size = new Size(106, 15);
            lblNetUp.TabIndex = 2;
            lblNetUp.Text = "Upload (качване): ";
            // 
            // lblNetDown
            // 
            lblNetDown.AutoSize = true;
            lblNetDown.Location = new Point(10, 85);
            lblNetDown.Name = "lblNetDown";
            lblNetDown.Size = new Size(122, 15);
            lblNetDown.TabIndex = 3;
            lblNetDown.Text = "Download (сваляне): ";
            // 
            // processList
            // 
            processList.Location = new Point(10, 138);
            processList.Name = "processList";
            processList.Size = new Size(500, 382);
            processList.TabIndex = 4;
            processList.UseCompatibleStateImageBehavior = false;
            processList.View = View.Details;
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(520, 10);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(400, 510);
            txtLogs.TabIndex = 5;
            // 
            // btnScan
            // 
            btnScan.Location = new Point(10, 530);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(200, 30);
            btnScan.TabIndex = 6;
            btnScan.Text = "Скенер за защита";
            btnScan.Click += btnScan_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(220, 530);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(100, 30);
            btnSettings.TabIndex = 0;
            btnSettings.Text = "Настройки";
            btnSettings.Click += btnSettings_Click;
            // 
            // lblThreatScore
            // 
            lblThreatScore.Location = new Point(10, 112);
            lblThreatScore.Name = "lblThreatScore";
            lblThreatScore.Size = new Size(242, 23);
            lblThreatScore.TabIndex = 7;
            // 
            // btnCPUTest
            // 
            btnCPUTest.Location = new Point(326, 530);
            btnCPUTest.Name = "btnCPUTest";
            btnCPUTest.Size = new Size(125, 30);
            btnCPUTest.TabIndex = 8;
            btnCPUTest.Text = "Тест на процесора";
            btnCPUTest.Click += btnCPUTest_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(940, 570);
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
            Name = "MainForm";
            Text = "Системно наблюдение";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;

            // lblCpuLoad
            Label lblCpuLoad = new Label();
            lblCpuLoad.Name = "lblCpuLoad";
            lblCpuLoad.Location = new Point(150, 10);
            lblCpuLoad.Size = new Size(150, 15);
            lblCpuLoad.Text = "CPU Натоварване: 0%";
            Controls.Add(lblCpuLoad);

            // txtLog
            TextBox txtLog = new TextBox();
            txtLog.Name = "txtLog";
            txtLog.Location = new Point(520, 530);
            txtLog.Size = new Size(400, 30);
            txtLog.Multiline = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            Controls.Add(txtLog);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

    }
}
