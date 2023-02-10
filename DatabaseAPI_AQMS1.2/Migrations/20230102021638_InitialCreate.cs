using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAPIAQMS1._2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MpdFlr = table.Column<int>(name: "Mpd_Flr", type: "int", nullable: false),
                    StreamTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pm25 = table.Column<double>(type: "float", nullable: false),
                    co2 = table.Column<double>(type: "float", nullable: false),
                    co = table.Column<double>(type: "float", nullable: false),
                    no2 = table.Column<double>(type: "float", nullable: false),
                    so2 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
