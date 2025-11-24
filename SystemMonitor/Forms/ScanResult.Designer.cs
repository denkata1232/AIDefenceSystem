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
            txtScan = new TextBox();
            SuspendLayout();
            // 
            // txtScan
            // 
            txtScan.Dock = DockStyle.Fill;
            txtScan.Location = new Point(0, 0);
            txtScan.Multiline = true;
            txtScan.Name = "txtScan";
            txtScan.ReadOnly = true;
            txtScan.ScrollBars = ScrollBars.Vertical;
            txtScan.Size = new Size(400, 500);
            txtScan.TabIndex = 0;
            // 
            // ScanResult
            // 
            ClientSize = new Size(400, 500);
            Controls.Add(txtScan);
            Name = "ScanResult";
            Text = "Резултат от сканиране";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}