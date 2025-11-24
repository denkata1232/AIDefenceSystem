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
                string msg = $"Високо използване на процесора засечено: {cpu:0}%";
                TriggerAlert(msg);
            }
        }

        public void CheckRam(float percent)
        {
            if (percent > RamThreshold)
            {
                string msg = $"Високо използване на Кеш памет засечено: {percent:0}%";
                TriggerAlert(msg);
            }
        }

        public void CheckNetwork(double upKB, double downKB)
        {
            if (upKB > NetworkSpikeKB || downKB > NetworkSpikeKB)
            {
                string msg = $"Мрежов скок засечен (качване {upKB:0} KB/s, сваляне {downKB:0} KB/s)";
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
                    string msg = $"Нов процес засечен: {p.ProcessName}.exe";
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
