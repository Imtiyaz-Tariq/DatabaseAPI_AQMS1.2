using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAPIAQMS1._2.Migrations
{
    /// <inheritdoc />
    public partial class changeMpdFlrco2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mpd_Flr",
                table: "Sensors",
                newName: "mpd_Flr");

            migrationBuilder.RenameColumn(
                name: "co2",
                table: "Sensors",
                newName: "o3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mpd_Flr",
                table: "Sensors",
                newName: "Mpd_Flr");

            migrationBuilder.RenameColumn(
                name: "o3",
                table: "Sensors",
                newName: "co2");
        }
    }
}
