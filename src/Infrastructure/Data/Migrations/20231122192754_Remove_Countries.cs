using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacClientSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Countries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripTickOrders_Countries_NationalityId",
                table: "TripTickOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TripTickOrders_Countries_ResidenceCountryId",
                table: "TripTickOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TripTickOrders_Countries_VehicleRegistrationCountryId",
                table: "TripTickOrders");

            migrationBuilder.DropIndex(
                name: "IX_TripTickOrders_NationalityId",
                table: "TripTickOrders");

            migrationBuilder.DropIndex(
                name: "IX_TripTickOrders_ResidenceCountryId",
                table: "TripTickOrders");

            migrationBuilder.DropIndex(
                name: "IX_TripTickOrders_VehicleRegistrationCountryId",
                table: "TripTickOrders");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "TripTickOrders");

            migrationBuilder.DropColumn(
                name: "ResidenceCountryId",
                table: "TripTickOrders");

            migrationBuilder.DropColumn(
                name: "VehicleRegistrationCountryId",
                table: "TripTickOrders");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "TripTickOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidenceCountry",
                table: "TripTickOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleRegistrationCountry",
                table: "TripTickOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "TripTickOrders");

            migrationBuilder.DropColumn(
                name: "ResidenceCountry",
                table: "TripTickOrders");

            migrationBuilder.DropColumn(
                name: "VehicleRegistrationCountry",
                table: "TripTickOrders");

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "TripTickOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResidenceCountryId",
                table: "TripTickOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleRegistrationCountryId",
                table: "TripTickOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_NationalityId",
                table: "TripTickOrders",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_ResidenceCountryId",
                table: "TripTickOrders",
                column: "ResidenceCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_VehicleRegistrationCountryId",
                table: "TripTickOrders",
                column: "VehicleRegistrationCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripTickOrders_Countries_NationalityId",
                table: "TripTickOrders",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripTickOrders_Countries_ResidenceCountryId",
                table: "TripTickOrders",
                column: "ResidenceCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripTickOrders_Countries_VehicleRegistrationCountryId",
                table: "TripTickOrders",
                column: "VehicleRegistrationCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
