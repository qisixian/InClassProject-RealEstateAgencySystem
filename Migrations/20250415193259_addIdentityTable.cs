using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateAgencySystem.Migrations
{
    /// <inheritdoc />
    public partial class addIdentityTable : Migration
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

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "2598 K St, Surrey, BC, Canada", "979-508-1377", "V4O2X6" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1528 T St, North Vancouver, BC, Canada", "462-169-8414", "V4W7E8" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "418 B St, Vancouver, BC, Canada", "228-891-3402", "V7K5K7" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "5486 S St, Burnaby, BC, Canada", "482-265-9080", "V5U1H7" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "4737 F St, Delta, BC, Canada", "137-226-4669", "V6Z1H7" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "9997 I St, Langley, BC, Canada", "243-717-3767", "V2Z4W4" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "7689 T St, Surrey, BC, Canada", "321-447-9284", "V5F1J5" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "8630 M St, Coquitlam, BC, Canada", "390-132-7432", "V2V4E9" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "2318 G St, Burnaby, BC, Canada", "492-452-1205", "V1H6W9" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "4481 G St, West Vancouver, BC, Canada", "617-716-2877", "V4B3V2" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1476 W St, Surrey, BC, Canada", "216-161-4384", "V8K7E2" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "172 N St, Burnaby, BC, Canada", "570-405-3330", "V9B4J1" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "3619 O St, Delta, BC, Canada", "879-325-6126", "V9H4G4" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1113 H St, West Vancouver, BC, Canada", "605-550-2527", "V8Y4F9" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "2932 U St, North Vancouver, BC, Canada", "846-746-5253", "V4Y1Z3" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 16,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1327 R St, Langley, BC, Canada", "251-627-3358", "V8D6I3" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 17,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "9705 I St, Surrey, BC, Canada", "627-854-5716", "V5E2Y3" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 18,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1536 O St, Coquitlam, BC, Canada", "857-909-2250", "V3A2E5" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 19,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "656 W St, Langley, BC, Canada", "919-882-3139", "V4Y6B6" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 20,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "7978 P St, West Vancouver, BC, Canada", "389-296-1564", "V1B4A3" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 1,
                columns: new[] { "Bathrooms", "BuildYear", "City", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 2, 1992, "Vancouver", "Beautiful Apartment in a great neighborhood. Built in 2018.", new DateTime(2025, 4, 2, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(7960), 8, "V4F3L2", "5322 D Ave", "Apartment", 4107m, 2633.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 2,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 4, 2, 2006, "Surrey", "Rented", "Beautiful House in a great neighborhood. Built in 2012.", new DateTime(2025, 4, 9, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8840), 9, "V5P8C4", "6872 J Ave", "Condo", 4308m, null, 2627.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 3,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 3, 3, 2017, "Sold", "Beautiful Duplex in a great neighborhood. Built in 2011.", new DateTime(2025, 3, 21, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8850), 3, "V9P5D6", "7818 B Ave", "House", null, 1497239m, 4702.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 4,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 1, 5, 2022, "Coquitlam", "Beautiful House in a great neighborhood. Built in 1980.", new DateTime(2025, 4, 1, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8860), 20, "V4K2Z1", "5392 N Ave", "Apartment", 1258078m, 4651.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 5,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 1, 5, 1984, "Langley", "Rented", "Beautiful Townhouse in a great neighborhood. Built in 2003.", new DateTime(2025, 4, 12, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8860), 3, "V4J1J9", "5736 T Ave", "House", 4417m, 4922.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 6,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2, 2, 1980, "Burnaby", "Beautiful Apartment in a great neighborhood. Built in 2014.", new DateTime(2025, 4, 5, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8890), 18, "V1V9U9", "6306 U Ave", 939459m, 2693.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 7,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "PostalCode", "PropertyAddress", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 3, 4, 2022, "North Vancouver", "For Rent", "Beautiful House in a great neighborhood. Built in 2009.", new DateTime(2025, 4, 10, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8900), "V7F6Z3", "8660 I Ave", 2386m, null, 4881.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 8,
                columns: new[] { "Bathrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 4, 2017, "New Westminster", "Sold", "Beautiful Townhouse in a great neighborhood. Built in 2002.", new DateTime(2025, 4, 12, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8910), 11, "V6Z1R3", "1060 W Ave", "Duplex", 1041392m, 2732.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 9,
                columns: new[] { "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 1993, "New Westminster", "Rented", "Beautiful House in a great neighborhood. Built in 2020.", new DateTime(2025, 3, 23, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8910), 8, "V9P1Z1", "2528 R Ave", "Condo", 1774m, null, 4368.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 10,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 4, 4, 1988, "West Vancouver", "Sold", "Beautiful House in a great neighborhood. Built in 1981.", new DateTime(2025, 4, 9, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8920), 20, "V8D1I8", "2242 Z Ave", "Duplex", null, 447528m, 3491.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 11,
                columns: new[] { "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 1991, "West Vancouver", "Rented", "Beautiful Duplex in a great neighborhood. Built in 1985.", new DateTime(2025, 4, 5, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8930), 16, "V2U1S1", "6054 T Ave", 4942m, 4851.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 12,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 1, 5, 2007, "Sold", "Beautiful Condo in a great neighborhood. Built in 2000.", new DateTime(2025, 3, 19, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8930), 12, "V3M6X9", "8150 C Ave", "Duplex", null, 1673352m, 2669.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 13,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "Description", "ListingDate", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 2, 4, 1985, "New Westminster", "Beautiful Condo in a great neighborhood. Built in 2021.", new DateTime(2025, 3, 30, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8940), "V2H4X8", "4009 A Ave", "Townhouse", 4166m, 1947.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 14,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 1, 1, 2020, "Richmond", "Sold", "Beautiful Condo in a great neighborhood. Built in 1984.", new DateTime(2025, 4, 14, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8950), 18, "V7U7S5", "7705 P Ave", "Condo", null, 437304m, 1080.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 15,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2, 3, 2011, "Coquitlam", "Sold", "Beautiful Duplex in a great neighborhood. Built in 1990.", new DateTime(2025, 4, 11, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8950), 14, "V2M2W3", "2186 R Ave", "Townhouse", null, 1772822m, 1007.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 16,
                columns: new[] { "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2018, "Langley", "Sold", "Beautiful Condo in a great neighborhood. Built in 1980.", new DateTime(2025, 4, 8, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8960), 4, "V9I1O3", "7694 R Ave", "Condo", 1929638m, 4018.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 17,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2, 1, 1986, "Langley", "For Rent", "Beautiful Townhouse in a great neighborhood. Built in 1986.", new DateTime(2025, 3, 18, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8970), 6, "V1E1W3", "8166 J Ave", "Apartment", 3324m, null, 4997.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 18,
                columns: new[] { "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 1, 1999, "Delta", "For Sale", "Beautiful House in a great neighborhood. Built in 2007.", new DateTime(2025, 4, 6, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8980), 15, "V2J5B1", "6410 J Ave", "Condo", 633776m, 3601.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 19,
                columns: new[] { "Bathrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 4, 2019, "Richmond", "Rented", "Beautiful Condo in a great neighborhood. Built in 1985.", new DateTime(2025, 3, 18, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8980), 12, "V6D2M5", "9151 I Ave", 3235m, 1863.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 20,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 3, 2, 2019, "West Vancouver", "Beautiful Duplex in a great neighborhood. Built in 2017.", new DateTime(2025, 3, 27, 12, 32, 58, 796, DateTimeKind.Local).AddTicks(8990), 7, "V1K6W1", "8745 N Ave", "Duplex", 1675273m, 2575.0 });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 1,
                columns: new[] { "Dryer", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "OtherAmenities", "ParkingLot", "Washer" },
                values: new object[] { false, false, false, false, false, false, "", true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 2,
                columns: new[] { "AirConditioning", "Cooktop", "Dryer", "Elevator", "FitnessRoom", "Microwave", "ParkingLot", "Refrigerator", "SecuritySystem" },
                values: new object[] { false, false, false, true, true, true, true, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 3,
                columns: new[] { "Cooktop", "Dryer", "Elevator", "FireSprinklerSystem", "FitnessRoom", "Microwave", "OtherAmenities", "ParkingLot", "SwimmingPool" },
                values: new object[] { true, false, false, false, false, true, "Close to public transport, shopping center nearby", true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 4,
                columns: new[] { "AirConditioning", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "PetFriendly", "Washer" },
                values: new object[] { false, false, true, true, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 5,
                columns: new[] { "Elevator", "FitnessRoom", "Heating", "Locker", "ParkingLot", "SecuritySystem" },
                values: new object[] { true, true, false, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 6,
                columns: new[] { "Cooktop", "Dishwasher", "Heating", "Microwave", "Refrigerator", "SecuritySystem", "SwimmingPool" },
                values: new object[] { true, true, false, false, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 7,
                columns: new[] { "AirConditioning", "Dryer", "Elevator", "OtherAmenities", "Refrigerator", "SecuritySystem", "Washer" },
                values: new object[] { true, true, true, "", true, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 8,
                columns: new[] { "FireSprinklerSystem", "Heating", "Locker", "PetFriendly", "SecuritySystem", "Washer" },
                values: new object[] { false, false, true, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 9,
                columns: new[] { "Cooktop", "Dishwasher", "FitnessRoom", "OtherAmenities", "ParkingLot", "PetFriendly", "SecuritySystem", "SwimmingPool" },
                values: new object[] { true, true, false, "", true, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 10,
                columns: new[] { "AirConditioning", "Dishwasher", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "ParkingLot", "PetFriendly", "Washer" },
                values: new object[] { true, true, false, true, false, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 11,
                columns: new[] { "Cooktop", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "SwimmingPool", "Washer" },
                values: new object[] { true, true, false, false, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 12,
                columns: new[] { "AirConditioning", "Cooktop", "Dishwasher", "Dryer", "Elevator", "FireSprinklerSystem", "FitnessRoom", "Heating", "Microwave", "OtherAmenities", "ParkingLot", "SwimmingPool", "Washer" },
                values: new object[] { false, false, true, false, false, true, false, false, false, "", false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 13,
                columns: new[] { "AirConditioning", "Dishwasher", "Dryer", "FitnessRoom", "Heating", "PetFriendly", "Refrigerator", "SwimmingPool", "Washer" },
                values: new object[] { false, true, false, true, true, true, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 14,
                columns: new[] { "AirConditioning", "Dishwasher", "Elevator", "Microwave", "ParkingLot", "PetFriendly", "Refrigerator", "SecuritySystem", "Washer" },
                values: new object[] { true, true, false, false, false, true, false, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 15,
                columns: new[] { "Dishwasher", "FitnessRoom", "Locker", "PetFriendly", "SecuritySystem", "Washer" },
                values: new object[] { false, true, false, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 16,
                columns: new[] { "AirConditioning", "FireSprinklerSystem", "OtherAmenities", "PetFriendly", "Refrigerator", "SwimmingPool", "Washer" },
                values: new object[] { true, true, "", true, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 17,
                columns: new[] { "AirConditioning", "Cooktop", "Dryer", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "Refrigerator", "SecuritySystem", "SwimmingPool", "Washer" },
                values: new object[] { false, true, true, true, false, false, false, false, false, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 18,
                columns: new[] { "AirConditioning", "Dishwasher", "Elevator", "FitnessRoom", "Heating", "Microwave", "OtherAmenities", "ParkingLot", "Refrigerator", "SecuritySystem", "Washer" },
                values: new object[] { false, true, false, false, true, false, "", true, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 19,
                columns: new[] { "AirConditioning", "Dishwasher", "Elevator", "FireSprinklerSystem", "FitnessRoom", "Refrigerator", "SecuritySystem", "Washer" },
                values: new object[] { false, false, false, false, true, true, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 20,
                columns: new[] { "AirConditioning", "Cooktop", "Dishwasher", "Elevator", "FitnessRoom", "Heating", "Microwave", "OtherAmenities", "PetFriendly", "Refrigerator", "SecuritySystem" },
                values: new object[] { true, false, true, false, true, false, true, "Close to public transport, shopping center nearby", true, true, false });

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1580 B St, West Vancouver, BC, Canada", "827-383-2545", "V9P8L6" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "159 K St, Vancouver, BC, Canada", "777-839-4397", "V7M3R6" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "8846 D St, Delta, BC, Canada", "981-572-3074", "V7B1I7" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "6552 R St, New Westminster, BC, Canada", "109-986-6177", "V8D9E6" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "6957 D St, North Vancouver, BC, Canada", "599-936-1292", "V5K3Z3" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "6621 M St, Langley, BC, Canada", "185-653-7655", "V7M3W2" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "4494 P St, Richmond, BC, Canada", "840-736-4269", "V9B6O4" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "9084 E St, West Vancouver, BC, Canada", "764-993-5958", "V8Z4L5" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "7654 H St, Vancouver, BC, Canada", "946-591-6741", "V2U6W5" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1565 I St, Vancouver, BC, Canada", "190-675-6167", "V7A1K2" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "2556 W St, Langley, BC, Canada", "664-864-6435", "V2E2P3" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "5220 E St, Vancouver, BC, Canada", "933-149-5858", "V3G3T6" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "9561 T St, Vancouver, BC, Canada", "325-402-5943", "V1N8M7" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "8281 R St, North Vancouver, BC, Canada", "481-836-6170", "V9Y4H8" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1552 V St, Langley, BC, Canada", "134-688-7724", "V5S8M1" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 16,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "5004 M St, Coquitlam, BC, Canada", "789-687-7689", "V2Q8H1" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 17,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "9310 B St, New Westminster, BC, Canada", "902-873-9618", "V8G1I7" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 18,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "8958 H St, West Vancouver, BC, Canada", "377-700-8288", "V3F1G7" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 19,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "1798 J St, Langley, BC, Canada", "257-456-9090", "V6B1V1" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 20,
                columns: new[] { "ContactAddress", "Phone", "PostalCode" },
                values: new object[] { "2104 P St, North Vancouver, BC, Canada", "301-676-6805", "V6T3K9" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 1,
                columns: new[] { "Bathrooms", "BuildYear", "City", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 1, 2022, "Richmond", "Beautiful Duplex in a great neighborhood. Built in 2014.", new DateTime(2025, 3, 14, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(1620), 11, "V1B8V3", "6122 O Ave", "Condo", 2560m, 3315.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 2,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 3, 3, 2009, "Vancouver", "Sold", "Beautiful Condo in a great neighborhood. Built in 2008.", new DateTime(2025, 3, 12, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2500), 1, "V4D8L7", "8806 E Ave", "Apartment", null, 503405m, 1107.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 3,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 4, 4, 2019, "For Rent", "Beautiful Townhouse in a great neighborhood. Built in 2020.", new DateTime(2025, 3, 10, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2510), 4, "V4W7L1", "4501 Y Ave", "Townhouse", 3264m, null, 3596.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 4,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2, 4, 1984, "North Vancouver", "Beautiful Duplex in a great neighborhood. Built in 2019.", new DateTime(2025, 3, 13, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2520), 14, "V7Y9R6", "8645 R Ave", "House", 755236m, 3679.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 5,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 2, 1, 2021, "Richmond", "For Rent", "Beautiful Townhouse in a great neighborhood. Built in 1986.", new DateTime(2025, 2, 24, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2530), 13, "V7R1P6", "2477 T Ave", "Townhouse", 2217m, 1368.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 6,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 3, 3, 1992, "West Vancouver", "Beautiful Duplex in a great neighborhood. Built in 2010.", new DateTime(2025, 2, 24, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2530), 15, "V3G5S8", "6199 M Ave", 767165m, 3623.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 7,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "PostalCode", "PropertyAddress", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 4, 3, 2018, "Surrey", "For Sale", "Beautiful Townhouse in a great neighborhood. Built in 2014.", new DateTime(2025, 2, 27, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2540), "V5M6O5", "2066 Q Ave", null, 604733m, 4971.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 8,
                columns: new[] { "Bathrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2, 1992, "Coquitlam", "For Sale", "Beautiful Apartment in a great neighborhood. Built in 1985.", new DateTime(2025, 3, 9, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2560), 13, "V8G2G3", "9332 G Ave", "Townhouse", 1835123m, 1986.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 9,
                columns: new[] { "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2012, "Vancouver", "For Sale", "Beautiful Apartment in a great neighborhood. Built in 1997.", new DateTime(2025, 3, 16, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2560), 1, "V4J7Q2", "8773 W Ave", "Townhouse", null, 582731m, 1976.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 10,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 1, 3, 1983, "Coquitlam", "Rented", "Beautiful Apartment in a great neighborhood. Built in 2000.", new DateTime(2025, 3, 8, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2570), 19, "V6H8N5", "7649 T Ave", "Condo", 4626m, null, 4202.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 11,
                columns: new[] { "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 1984, "Langley", "For Rent", "Beautiful Townhouse in a great neighborhood. Built in 2000.", new DateTime(2025, 3, 16, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2580), 18, "V7C4X7", "4015 F Ave", 1584m, 3630.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 12,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2, 1, 2003, "Rented", "Beautiful Apartment in a great neighborhood. Built in 2011.", new DateTime(2025, 3, 7, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2580), 13, "V2F6O5", "7468 N Ave", "Condo", 3149m, null, 3644.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 13,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "Description", "ListingDate", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 4, 5, 1999, "Burnaby", "Beautiful House in a great neighborhood. Built in 2002.", new DateTime(2025, 2, 28, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2590), "V2P4V5", "1005 W Ave", "Apartment", 3880m, 1848.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 14,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 3, 2, 2014, "North Vancouver", "Rented", "Beautiful Duplex in a great neighborhood. Built in 2022.", new DateTime(2025, 3, 1, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2590), 11, "V6R4G9", "9916 U Ave", "Townhouse", 3156m, null, 1263.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 15,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 4, 5, 2010, "Delta", "Rented", "Beautiful Duplex in a great neighborhood. Built in 2022.", new DateTime(2025, 3, 14, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2600), 16, "V5H3Z2", "5072 Y Ave", "House", 4360m, null, 4347.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 16,
                columns: new[] { "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 1994, "Vancouver", "For Sale", "Beautiful Townhouse in a great neighborhood. Built in 2015.", new DateTime(2025, 3, 1, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2610), 13, "V1H6C1", "4302 Q Ave", "Apartment", 1231073m, 4557.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 17,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 3, 3, 1994, "Delta", "Sold", "Beautiful Duplex in a great neighborhood. Built in 2022.", new DateTime(2025, 3, 12, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2610), 13, "V9O1L4", "425 R Ave", "Townhouse", null, 571415m, 2341.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 18,
                columns: new[] { "Bedrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2, 1985, "Surrey", "Sold", "Beautiful House in a great neighborhood. Built in 2015.", new DateTime(2025, 3, 16, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2620), 2, "V8I3K5", "7181 C Ave", "House", 1328258m, 1780.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 19,
                columns: new[] { "Bathrooms", "BuildYear", "City", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "RentalPrice", "SizeOfHouse" },
                values: new object[] { 1, 1990, "Burnaby", "For Rent", "Beautiful Condo in a great neighborhood. Built in 1980.", new DateTime(2025, 3, 14, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2630), 13, "V1M1L6", "6780 D Ave", 2241m, 3845.0 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 20,
                columns: new[] { "Bathrooms", "Bedrooms", "BuildYear", "City", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "SellingPrice", "SizeOfHouse" },
                values: new object[] { 2, 3, 1984, "Richmond", "Beautiful Apartment in a great neighborhood. Built in 1993.", new DateTime(2025, 2, 20, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2630), 3, "V1T7I2", "8036 S Ave", "House", 1557945m, 3152.0 });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 1,
                columns: new[] { "Dryer", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "OtherAmenities", "ParkingLot", "Washer" },
                values: new object[] { true, true, true, true, true, true, "Close to public transport, shopping center nearby", false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 2,
                columns: new[] { "AirConditioning", "Cooktop", "Dryer", "Elevator", "FitnessRoom", "Microwave", "ParkingLot", "Refrigerator", "SecuritySystem" },
                values: new object[] { true, true, true, false, false, false, false, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 3,
                columns: new[] { "Cooktop", "Dryer", "Elevator", "FireSprinklerSystem", "FitnessRoom", "Microwave", "OtherAmenities", "ParkingLot", "SwimmingPool" },
                values: new object[] { false, true, true, true, true, false, "", false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 4,
                columns: new[] { "AirConditioning", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "PetFriendly", "Washer" },
                values: new object[] { true, true, false, false, true, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 5,
                columns: new[] { "Elevator", "FitnessRoom", "Heating", "Locker", "ParkingLot", "SecuritySystem" },
                values: new object[] { false, false, true, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 6,
                columns: new[] { "Cooktop", "Dishwasher", "Heating", "Microwave", "Refrigerator", "SecuritySystem", "SwimmingPool" },
                values: new object[] { false, false, true, true, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 7,
                columns: new[] { "AirConditioning", "Dryer", "Elevator", "OtherAmenities", "Refrigerator", "SecuritySystem", "Washer" },
                values: new object[] { false, false, false, "Close to public transport, shopping center nearby", false, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 8,
                columns: new[] { "FireSprinklerSystem", "Heating", "Locker", "PetFriendly", "SecuritySystem", "Washer" },
                values: new object[] { true, true, false, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 9,
                columns: new[] { "Cooktop", "Dishwasher", "FitnessRoom", "OtherAmenities", "ParkingLot", "PetFriendly", "SecuritySystem", "SwimmingPool" },
                values: new object[] { false, false, true, "Close to public transport, shopping center nearby", false, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 10,
                columns: new[] { "AirConditioning", "Dishwasher", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "ParkingLot", "PetFriendly", "Washer" },
                values: new object[] { false, false, true, false, true, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 11,
                columns: new[] { "Cooktop", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "SwimmingPool", "Washer" },
                values: new object[] { false, false, true, true, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 12,
                columns: new[] { "AirConditioning", "Cooktop", "Dishwasher", "Dryer", "Elevator", "FireSprinklerSystem", "FitnessRoom", "Heating", "Microwave", "OtherAmenities", "ParkingLot", "SwimmingPool", "Washer" },
                values: new object[] { true, true, false, true, true, false, true, true, true, "Close to public transport, shopping center nearby", true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 13,
                columns: new[] { "AirConditioning", "Dishwasher", "Dryer", "FitnessRoom", "Heating", "PetFriendly", "Refrigerator", "SwimmingPool", "Washer" },
                values: new object[] { true, false, true, false, false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 14,
                columns: new[] { "AirConditioning", "Dishwasher", "Elevator", "Microwave", "ParkingLot", "PetFriendly", "Refrigerator", "SecuritySystem", "Washer" },
                values: new object[] { false, false, true, true, true, false, true, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 15,
                columns: new[] { "Dishwasher", "FitnessRoom", "Locker", "PetFriendly", "SecuritySystem", "Washer" },
                values: new object[] { true, false, true, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 16,
                columns: new[] { "AirConditioning", "FireSprinklerSystem", "OtherAmenities", "PetFriendly", "Refrigerator", "SwimmingPool", "Washer" },
                values: new object[] { false, false, "Close to public transport, shopping center nearby", false, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 17,
                columns: new[] { "AirConditioning", "Cooktop", "Dryer", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "Refrigerator", "SecuritySystem", "SwimmingPool", "Washer" },
                values: new object[] { true, false, false, false, true, true, true, true, true, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 18,
                columns: new[] { "AirConditioning", "Dishwasher", "Elevator", "FitnessRoom", "Heating", "Microwave", "OtherAmenities", "ParkingLot", "Refrigerator", "SecuritySystem", "Washer" },
                values: new object[] { true, false, true, true, false, true, "Close to public transport, shopping center nearby", false, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 19,
                columns: new[] { "AirConditioning", "Dishwasher", "Elevator", "FireSprinklerSystem", "FitnessRoom", "Refrigerator", "SecuritySystem", "Washer" },
                values: new object[] { true, true, true, true, false, false, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "PropertyAmenitiesID",
                keyValue: 20,
                columns: new[] { "AirConditioning", "Cooktop", "Dishwasher", "Elevator", "FitnessRoom", "Heating", "Microwave", "OtherAmenities", "PetFriendly", "Refrigerator", "SecuritySystem" },
                values: new object[] { false, true, false, true, false, true, false, "", false, false, true });
        }
    }
}
