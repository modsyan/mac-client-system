using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacClientSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init_Project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "TodoLists",
                newName: "TodoList");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "TodoItem");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItem",
                newName: "IX_TodoItem_ListId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePictureId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoList",
                table: "TodoList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryTitles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityTitles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DialingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUploads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicenseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    SourceOfLocalLicenseId = table.Column<int>(type: "int", nullable: false),
                    Gander = table.Column<int>(type: "int", nullable: false),
                    PassportTextId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseTypeId = table.Column<int>(type: "int", nullable: false),
                    LicenseDuration = table.Column<int>(type: "int", nullable: false),
                    PersonalPhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalDrivingLicenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassportImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseOrders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseOrders_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseOrders_Countries_SourceOfLocalLicenseId",
                        column: x => x.SourceOfLocalLicenseId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseOrders_FileUploads_LocalDrivingLicenseId",
                        column: x => x.LocalDrivingLicenseId,
                        principalTable: "FileUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseOrders_FileUploads_PassportImageId",
                        column: x => x.PassportImageId,
                        principalTable: "FileUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseOrders_FileUploads_PersonalPhotoId",
                        column: x => x.PersonalPhotoId,
                        principalTable: "FileUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseOrders_LicenseCategories_LicenseTypeId",
                        column: x => x.LicenseTypeId,
                        principalTable: "LicenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripTickOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    ResidenceCountryId = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    GovernmentalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraDriversCount = table.Column<int>(type: "int", nullable: false),
                    VehicleRegistrationCountryId = table.Column<int>(type: "int", nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleLicenseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleLicenseExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    VehiclePassengersCount = table.Column<int>(type: "int", nullable: false),
                    VehicleManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleWeight = table.Column<float>(type: "real", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    VehicleColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpholsteryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleEngineId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleCoverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirConditionerAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RadioAvailable = table.Column<bool>(type: "bit", nullable: false),
                    SpareTiresNumber = table.Column<int>(type: "int", nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plugins = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleRegistrationCopyDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassportDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalGovernmentalIdentityDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripTickOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripTickOrders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripTickOrders_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripTickOrders_Countries_ResidenceCountryId",
                        column: x => x.ResidenceCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripTickOrders_Countries_VehicleRegistrationCountryId",
                        column: x => x.VehicleRegistrationCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripTickOrders_FileUploads_PassportDocumentId",
                        column: x => x.PassportDocumentId,
                        principalTable: "FileUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripTickOrders_FileUploads_PersonalGovernmentalIdentityDocumentId",
                        column: x => x.PersonalGovernmentalIdentityDocumentId,
                        principalTable: "FileUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripTickOrders_FileUploads_VehicleRegistrationCopyDocumentId",
                        column: x => x.VehicleRegistrationCopyDocumentId,
                        principalTable: "FileUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripTickOrders_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfilePictureId",
                table: "AspNetUsers",
                column: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_AccountId",
                table: "LicenseOrders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_LicenseTypeId",
                table: "LicenseOrders",
                column: "LicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_LocalDrivingLicenseId",
                table: "LicenseOrders",
                column: "LocalDrivingLicenseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_NationalityId",
                table: "LicenseOrders",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_PassportImageId",
                table: "LicenseOrders",
                column: "PassportImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_PersonalPhotoId",
                table: "LicenseOrders",
                column: "PersonalPhotoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseOrders_SourceOfLocalLicenseId",
                table: "LicenseOrders",
                column: "SourceOfLocalLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_AccountId",
                table: "TripTickOrders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_NationalityId",
                table: "TripTickOrders",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_PassportDocumentId",
                table: "TripTickOrders",
                column: "PassportDocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_PersonalGovernmentalIdentityDocumentId",
                table: "TripTickOrders",
                column: "PersonalGovernmentalIdentityDocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_ResidenceCountryId",
                table: "TripTickOrders",
                column: "ResidenceCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_VehicleRegistrationCopyDocumentId",
                table: "TripTickOrders",
                column: "VehicleRegistrationCopyDocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_VehicleRegistrationCountryId",
                table: "TripTickOrders",
                column: "VehicleRegistrationCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTickOrders_VehicleTypeId",
                table: "TripTickOrders",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Accounts_AccountId",
                table: "AspNetUsers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FileUploads_ProfilePictureId",
                table: "AspNetUsers",
                column: "ProfilePictureId",
                principalTable: "FileUploads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoList_ListId",
                table: "TodoItem",
                column: "ListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Accounts_AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FileUploads_ProfilePictureId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoList_ListId",
                table: "TodoItem");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "LicenseOrders");

            migrationBuilder.DropTable(
                name: "TripTickOrders");

            migrationBuilder.DropTable(
                name: "LicenseCategories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "FileUploads");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfilePictureId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoList",
                table: "TodoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TodoList",
                newName: "TodoLists");

            migrationBuilder.RenameTable(
                name: "TodoItem",
                newName: "TodoItems");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItem_ListId",
                table: "TodoItems",
                newName: "IX_TodoItems_ListId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems",
                column: "ListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
