using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SystemMonitor.Core.Data
{
    public class TelemetryService
    {
        private System.Timers.Timer timer;
        private long prevBytesSent = 0;
        private long prevBytesReceived = 0;

        public TelemetryService()
        {
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
        }

        public void Start() => timer.Start();
        public void Stop() => timer.Stop();

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            double cpu = GetCpuUsage();
            double ram = GetRamUsage();
            var (up, down) = GetNetworkSpeed();
            int procCount = Process.GetProcesses().Length;
            int portCount = GetOpenPortsCount();

            var entry = new TelemetryEntry
            {
                Timestamp = DateTime.Now,
                Cpu = cpu,
                Ram = ram,
                Upload = up,
                Download = down,
                ProcessCount = procCount,
                OpenPorts = portCount
            };

            using var db = new TelemetryContext();
            db.Telemetry.Add(entry);
            await db.SaveChangesAsync();
        }

        private double GetCpuUsage()
        {
            using PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpu.NextValue();
            Thread.Sleep(1000);
            return Math.Round(cpu.NextValue(), 2);
        }

        private double GetRamUsage()
        {
            using PerformanceCounter ram = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            return Math.Round(ram.NextValue(), 2);
        }

        private (long upload, long download) GetNetworkSpeed()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces()
                .Where(i => i.OperationalStatus == OperationalStatus.Up);

            long sent = interfaces.Sum(i => i.GetIPv4Statistics().BytesSent);
            long received = interfaces.Sum(i => i.GetIPv4Statistics().BytesReceived);

            long uploadSpeed = sent - prevBytesSent;
            long downloadSpeed = received - prevBytesReceived;

            prevBytesSent = sent;
            prevBytesReceived = received;

            return (uploadSpeed, downloadSpeed);
        }

        private int GetOpenPortsCount()
        {
            return IPGlobalProperties.GetIPGlobalProperties()
                .GetActiveTcpListeners()
                .Length;
        }
    }
}
