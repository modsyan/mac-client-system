using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacClientSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class LicenseStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicenseStatus",
                table: "LicenseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseStatus",
                table: "LicenseOrders");
        }
    }
}
