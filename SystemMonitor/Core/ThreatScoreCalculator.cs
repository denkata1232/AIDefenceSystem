using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.Core
{
    public class ThreatScoreCalculator
    {
        public int Calculate(int cpuUsage, int ramUsage, long bytesSent, long bytesReceived, int unknownProcesses)
        {
            int score = 0;

            // CPU contribution
            if (cpuUsage > 80) score += 20;
            else if (cpuUsage > 60) score += 10;

            // RAM contribution
            if (ramUsage > 85) score += 20;
            else if (ramUsage > 70) score += 10;

            // Network anomalies
            if (bytesSent > 500_000 || bytesReceived > 500_000)
                score += 25;

            // Unknown processes
            score += unknownProcesses * 5;

            return Math.Min(score, 100);
        }

        public string GetStatus(int score)
        {
            if (score < 20) return "Safe";
            if (score < 50) return "Suspicious";
            if (score < 75) return "Warning";
            return "Critical";
        }
    }
}
