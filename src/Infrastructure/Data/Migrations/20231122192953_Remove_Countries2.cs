using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacClientSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Countries2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseOrders_Countries_SourceOfLocalLicenseId",
                table: "LicenseOrders");

            migrationBuilder.DropIndex(
                name: "IX_LicenseOrders_SourceOfLocalLicenseId",
                table: "LicenseOrders");

            migrationBuilder.DropColumn(
                name: "SourceOfLocalLicenseId",
                table: "LicenseOrders");

            migrationBuilder.AddColumn<string>(
                name: "SourceOfLocalLicense",
                table: "LicenseOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceOfLocalLicense",
                table: "LicenseOrders");

            migrationBuilder.AddColumn<int>(
                name: "SourceOfLocalLicenseId",
                table: "LicenseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_SourceOfLocalLicenseId",
                table: "LicenseOrders",
                column: "SourceOfLocalLicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseOrders_Countries_SourceOfLocalLicenseId",
                table: "LicenseOrders",
                column: "SourceOfLocalLicenseId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
