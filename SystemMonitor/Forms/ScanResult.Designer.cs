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
            this.txtScan = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            txtScan.Multiline = true;
            txtScan.ReadOnly = true;
            txtScan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtScan.Dock = System.Windows.Forms.DockStyle.Fill;

            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(txtScan);
            this.Text = "Scan Result";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}