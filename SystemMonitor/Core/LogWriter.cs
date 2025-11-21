using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SystemMonitor.Core
{
    internal class LogWriter
    {
        private static readonly string logPath = "system_logs.txt";

        public static void Write(string message)
        {
            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            File.AppendAllText(logPath, line + Environment.NewLine);
        }
    }
}
