using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SystemMonitor.Core
{
    internal class AlertManager
    {
        // Thresholds
        public float CpuThreshold = 90f;
        public float RamThreshold = 85f;
        public long NetworkSpikeKB = 5000; // 5 MB/s

        private HashSet<string> knownProcesses = new HashSet<string>();

        public void CheckCpu(float cpu)
        {
            if (cpu > CpuThreshold)
            {
                string msg = $"High CPU usage detected: {cpu:0}%";
                TriggerAlert(msg);
            }
        }

        public void CheckRam(float percent)
        {
            if (percent > RamThreshold)
            {
                string msg = $"High RAM usage detected: {percent:0}%";
                TriggerAlert(msg);
            }
        }

        public void CheckNetwork(double upKB, double downKB)
        {
            if (upKB > NetworkSpikeKB || downKB > NetworkSpikeKB)
            {
                string msg = $"Network spike detected (Up {upKB:0} KB/s, Down {downKB:0} KB/s)";
                TriggerAlert(msg);
            }
        }

        public void CheckNewProcesses(Process[] processes)
        {
            foreach (var p in processes)
            {
                if (!knownProcesses.Contains(p.ProcessName))
                {
                    knownProcesses.Add(p.ProcessName);
                    string msg = $"New process detected: {p.ProcessName}.exe";
                    TriggerAlert(msg);
                }
            }
        }

        private void TriggerAlert(string message)
        {
            LogWriter.Write(message);
            ToastAlert.ShowAlert(message);
        }
    }
}
