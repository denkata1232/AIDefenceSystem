using Microsoft.EntityFrameworkCore;
using SystemMonitor.Core.Data;

namespace SystemMonitor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var db = new TelemetryContext())
            {
                //db.Database.Migrate();
            }

            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}