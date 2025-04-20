using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateAgencySystem.Migrations
{
    /// <inheritdoc />
    public partial class initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ContactAddress = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Province = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    PropertyAddress = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PropertyType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BuildYear = table.Column<int>(type: "INTEGER", nullable: false),
                    SizeOfHouse = table.Column<double>(type: "REAL", nullable: false),
                    Bedrooms = table.Column<int>(type: "INTEGER", nullable: false),
                    Bathrooms = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentStatus = table.Column<string>(type: "TEXT", nullable: false),
                    ListingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RentalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    SellingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerCustomerId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_AspNetUsers_OwnerCustomerId",
                        column: x => x.OwnerCustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAmenities",
                columns: table => new
                {
                    PropertyAmenitiesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    Elevator = table.Column<bool>(type: "INTEGER", nullable: false),
                    Refrigerator = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cooktop = table.Column<bool>(type: "INTEGER", nullable: false),
                    Microwave = table.Column<bool>(type: "INTEGER", nullable: false),
                    Dishwasher = table.Column<bool>(type: "INTEGER", nullable: false),
                    FireSprinklerSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    Washer = table.Column<bool>(type: "INTEGER", nullable: false),
                    Dryer = table.Column<bool>(type: "INTEGER", nullable: false),
                    Heating = table.Column<bool>(type: "INTEGER", nullable: false),
                    AirConditioning = table.Column<bool>(type: "INTEGER", nullable: false),
                    SecuritySystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetFriendly = table.Column<bool>(type: "INTEGER", nullable: false),
                    FitnessRoom = table.Column<bool>(type: "INTEGER", nullable: false),
                    SwimmingPool = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParkingLot = table.Column<bool>(type: "INTEGER", nullable: false),
                    Locker = table.Column<bool>(type: "INTEGER", nullable: false),
                    OtherAmenities = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAmenities", x => x.PropertyAmenitiesId);
                    table.ForeignKey(
                        name: "FK_PropertyAmenities_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalRecords",
                columns: table => new
                {
                    RentalRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerCustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    TenantCustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractTerms = table.Column<string>(type: "TEXT", nullable: false),
                    RentalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DepositPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsFinalized = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRecords", x => x.RentalRecordId);
                    table.ForeignKey(
                        name: "FK_RentalRecords_AspNetUsers_OwnerCustomerId",
                        column: x => x.OwnerCustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalRecords_AspNetUsers_TenantCustomerId",
                        column: x => x.TenantCustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalRecords_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesRecords",
                columns: table => new
                {
                    SalesRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerCustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    BuyerCustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractTerms = table.Column<string>(type: "TEXT", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsFinalized = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRecords", x => x.SalesRecordId);
                    table.ForeignKey(
                        name: "FK_SalesRecords_AspNetUsers_BuyerCustomerId",
                        column: x => x.BuyerCustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRecords_AspNetUsers_OwnerCustomerId",
                        column: x => x.OwnerCustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRecords_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PropertyId",
                table: "Images",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerCustomerId",
                table: "Properties",
                column: "OwnerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAmenities_PropertyId",
                table: "PropertyAmenities",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_OwnerCustomerId",
                table: "RentalRecords",
                column: "OwnerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_PropertyId",
                table: "RentalRecords",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_TenantCustomerId",
                table: "RentalRecords",
                column: "TenantCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecords_BuyerCustomerId",
                table: "SalesRecords",
                column: "BuyerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecords_OwnerCustomerId",
                table: "SalesRecords",
                column: "OwnerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecords_PropertyId",
                table: "SalesRecords",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "PropertyAmenities");

            migrationBuilder.DropTable(
                name: "RentalRecords");

            migrationBuilder.DropTable(
                name: "SalesRecords");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
