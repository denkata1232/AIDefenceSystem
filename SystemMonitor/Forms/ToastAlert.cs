using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitor
{
    public partial class ToastAlert : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int displayTime = 3000;

        public ToastAlert(string text)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.ForeColor = Color.White;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(300, 60);
            this.TopMost = true;

            Label msg = new Label()
            {
                Text = text,
                ForeColor = Color.White,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(msg);

            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 20;
            this.Location = new Point(x, y);

            timer.Interval = displayTime;
            timer.Tick += (s, e) => this.Close();
            timer.Start();
        }

        public static void ShowAlert(string text)
        {
            new ToastAlert(text).Show();
        }
    }
}
