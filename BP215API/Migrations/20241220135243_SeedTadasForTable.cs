using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP215API.Migrations
{
    /// <inheritdoc />
    public partial class SeedTadasForTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Code", "Icon", "Name" },
                values: new object[] { "az", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/2560px-Flag_of_Azerbaijan.svg.png", "Azərbaycan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Code",
                keyValue: "az");
        }
    }
}
