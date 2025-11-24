using System.Diagnostics;

namespace SystemMonitor.Core.PCTesters
{
    public class CPUTester
    {
        public List<Thread> threads;
        private PerformanceCounter cpuCounter;
        private Stopwatch cpuBorderTime;

        public CPUTester()
        {
            threads = new List<Thread>();
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuBorderTime = new Stopwatch();
        }
        public void StartTest(float cpuTreashHold = 95)
        {
            cpuTreashHold = Math.Max(0, cpuTreashHold);
            cpuTreashHold = Math.Min(cpuTreashHold, 95);

            float cpu = cpuCounter.NextValue();
            while (cpu < cpuTreashHold/* || cpuBorderTime.Elapsed.Seconds < 3*/)
            {
                if (cpu >= cpuTreashHold)
                {
                    cpuBorderTime.Start();
                }
                Thread t = new Thread(StressCpu);
                t.IsBackground = true;
                threads.Add(t);
                t.Start();
            }
            foreach (Thread t in threads)
            {
#pragma warning disable SYSLIB0006
                t.Abort();
#pragma warning restore SYSLIB0006
            }
            MessageBox.Show($"Активни процеси: {threads.Count}");
            threads.Clear();
            cpuBorderTime.Reset();
        }
        private void StressCpu()
        {
            while (true)
            {
                //double x = Math.Sqrt(new Random().NextDouble());
                double x = new Random().Next(0, 100) + new Random().Next(0, 100);
            }
        }


    }
}
