using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacClientSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeLicenseCategoryFromLicenseOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseOrders_LicenseCategories_LicenseTypeId",
                table: "LicenseOrders");

            migrationBuilder.DropIndex(
                name: "IX_LicenseOrders_LicenseTypeId",
                table: "LicenseOrders");

            migrationBuilder.DropColumn(
                name: "LicenseTypeId",
                table: "LicenseOrders");

            migrationBuilder.AlterColumn<string>(
                name: "Gander",
                table: "LicenseOrders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "LicenseType",
                table: "LicenseOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseType",
                table: "LicenseOrders");

            migrationBuilder.AlterColumn<int>(
                name: "Gander",
                table: "LicenseOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LicenseTypeId",
                table: "LicenseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_LicenseTypeId",
                table: "LicenseOrders",
                column: "LicenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseOrders_LicenseCategories_LicenseTypeId",
                table: "LicenseOrders",
                column: "LicenseTypeId",
                principalTable: "LicenseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
