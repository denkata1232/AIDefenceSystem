using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.Core.PCTesters
{
    public class AdvancedCpuTester
    {
        private readonly List<Task> workers = new();
        private CancellationTokenSource? cts;
        private readonly PerformanceCounter cpuCounter;

        public Action<float>? OnCpuUpdated;     // callback to update UI
        public Action<string>? OnStatusChanged; // callback for logs or UI text

        public AdvancedCpuTester()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        /// <summary>
        /// Starts the CPU stress test with desired load level (0-100%)
        /// </summary>
        public void Start(int targetLoadPercent = 100, bool adaptiveMode = false)
        {
            Stop(); // safety

            int coreCount = Environment.ProcessorCount;
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            OnStatusChanged?.Invoke($"Starting stress test on {coreCount} cores…");

            for (int i = 0; i < coreCount; i++)
            {
                var task = Task.Run(() => StressLoop(targetLoadPercent, adaptiveMode, token), token);
                workers.Add(task);
            }

            // Start CPU monitoring loop
            Task.Run(() => MonitorCpu(token));
        }

        /// <summary>
        /// Stops the test safely
        /// </summary>
        public void Stop()
        {
            if (cts == null)
                return;

            OnStatusChanged?.Invoke("Stopping CPU test…");
            cts.Cancel();

            try
            {
                Task.WaitAll(workers.ToArray(), 500);
            }
            catch { /* ignore */ }

            workers.Clear();
            cts.Dispose();
            cts = null;

            OnStatusChanged?.Invoke("CPU test stopped.");
        }

        /// <summary>
        /// The stress loop running on each CPU core
        /// </summary>
        private void StressLoop(int targetLoadPercent, bool adaptiveMode, CancellationToken token)
        {
            double busyTime = targetLoadPercent / 100.0;
            double idleTime = 1.0 - busyTime;

            Stopwatch sw = new();

            while (!token.IsCancellationRequested)
            {
                sw.Restart();

                // Busy workload
                while (sw.Elapsed.TotalMilliseconds < (busyTime * 10))
                {
                    double x = Math.Sqrt(123456.789); // heavy calculation
                    if (token.IsCancellationRequested)
                        return;
                }

                // Sleep to regulate CPU load
                if (!adaptiveMode)
                {
                    Thread.Sleep((int)(idleTime * 10));
                }
            }
        }

        /// <summary>
        /// Monitors CPU usage and fires events for UI updates
        /// </summary>
        private async Task MonitorCpu(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                float cpu = cpuCounter.NextValue();
                OnCpuUpdated?.Invoke(cpu);

                if (cpu > 95)
                {
                    OnStatusChanged?.Invoke("Високо натоварване! CPU > 95%");
                }

                await Task.Delay(500);
            }
        }
    }
}
