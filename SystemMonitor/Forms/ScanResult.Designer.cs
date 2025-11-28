namespace SystemMonitor.Forms
{
    partial class ScanResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtScan;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanResult));
            txtScan = new TextBox();
            SuspendLayout();
            // 
            // txtScan
            // 
            txtScan.BackColor = Color.FromArgb(0, 27, 56);
            txtScan.Dock = DockStyle.Fill;
            txtScan.ForeColor = SystemColors.Info;
            txtScan.Location = new Point(0, 0);
            txtScan.Multiline = true;
            txtScan.Name = "txtScan";
            txtScan.ReadOnly = true;
            txtScan.ScrollBars = ScrollBars.Vertical;
            txtScan.Size = new Size(277, 210);
            txtScan.TabIndex = 0;
            // 
            // ScanResult
            // 
            AutoSize = true;
            ClientSize = new Size(277, 210);
            Controls.Add(txtScan);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScanResult";
            Text = "Резултат от сканиране";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}