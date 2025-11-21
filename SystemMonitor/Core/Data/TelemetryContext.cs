using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SystemMonitor.Core.Data
{
    public class TelemetryContext : DbContext
    {
        public DbSet<TelemetryEntry> Telemetry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=telemetry.db");
        }
    }
}
