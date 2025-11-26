using System.Diagnostics;

namespace SystemMonitor.Core.PCTesters
{
    public class CPUTester
    {
        public List<Thread> threads;
        private PerformanceCounter cpuCounter;
        private Stopwatch cpuBorderTime;

        // Safe stop flag
        private volatile bool threadStopRequested = false;

        public CPUTester()
        {
            threads = new List<Thread>();
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuBorderTime = new Stopwatch();
        }
        public void StartTest(float cpuThreshold = 100)
        {
            threadStopRequested = false; // reset stop flag

            cpuThreshold = Math.Clamp(cpuThreshold, 0, 100);

            float cpu = cpuCounter.NextValue();
            cpuBorderTime.Start();

            //while (cpuBorderTime.Elapsed.Seconds < 3)
            while (cpuBorderTime.Elapsed.Seconds < 3)
            {
                if(cpu < cpuThreshold)
                {
                    cpuBorderTime.Restart();
                }
                Thread t = new Thread(StressCpu)
                {
                    IsBackground = true
                };
                threads.Add(t);
                t.Start();

                cpu = cpuCounter.NextValue();
            }

            //threads stop safely
            threadStopRequested = true;

            // Wait for threads
            foreach (var t in threads)
            {
                if (t.IsAlive)
                    t.Join(200); // 200ms wait max per thread
            }

            MessageBox.Show($"Активни процеси: {threads.Count}");

            threads.Clear();
            cpuBorderTime.Reset();
        }

        private void StressCpu()
        {
            while (!threadStopRequested)
            {
                double x = Math.Sqrt(12345.6789);
            }
        }
    }
}
