using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitor.Forms
{
    public partial class ScanResult : Form
    {
        public ScanResult(string resultText)
        {
            InitializeComponent();
            txtScan.Text = resultText;
        }
    }
}
