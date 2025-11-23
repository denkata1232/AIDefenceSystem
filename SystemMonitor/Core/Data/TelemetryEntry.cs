using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.Core.Data
{
    public class TelemetryEntry
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }

        public double Cpu { get; set; }
        public double Ram { get; set; }

        public long Upload { get; set; }
        public long Download { get; set; }

        public int ProcessCount { get; set; }
        public int OpenPorts { get; set; }

        public int ThreatScore { get; set; }
        public string ThreatStatus { get; set; }
    }
}
