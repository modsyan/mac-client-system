using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacClientSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Countries3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseOrders_Countries_NationalityId",
                table: "LicenseOrders");

            migrationBuilder.DropIndex(
                name: "IX_LicenseOrders_NationalityId",
                table: "LicenseOrders");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "LicenseOrders");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "TripTickOrders",
                newName: "NationalityCountry");

            migrationBuilder.RenameColumn(
                name: "SourceOfLocalLicense",
                table: "LicenseOrders",
                newName: "SourceOfLocalLicenseCountry");

            migrationBuilder.AddColumn<string>(
                name: "NationalityCountry",
                table: "LicenseOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalityCountry",
                table: "LicenseOrders");

            migrationBuilder.RenameColumn(
                name: "NationalityCountry",
                table: "TripTickOrders",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "SourceOfLocalLicenseCountry",
                table: "LicenseOrders",
                newName: "SourceOfLocalLicense");

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "LicenseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_NationalityId",
                table: "LicenseOrders",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseOrders_Countries_NationalityId",
                table: "LicenseOrders",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
