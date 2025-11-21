using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.Core
{
    public class AppSettings
    {
        public bool MonitoringEnabled { get; set; } = true;
        public bool ScreenshotLogging { get; set; } = false;
        public int AlertVolume { get; set; } = 70;
        public bool NetworkMonitoring { get; set; } = true;
        public string Theme { get; set; } = "Dark";
    }
}
