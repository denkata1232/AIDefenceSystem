using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemMonitor.Migrations
{
    /// <inheritdoc />
    public partial class Threats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThreatScore",
                table: "Telemetry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ThreatStatus",
                table: "Telemetry",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreatScore",
                table: "Telemetry");

            migrationBuilder.DropColumn(
                name: "ThreatStatus",
                table: "Telemetry");
        }
    }
}
