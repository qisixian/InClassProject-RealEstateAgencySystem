using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateAgencySystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ContactAddress = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyID = table.Column<int>(type: "INTEGER", nullable: false)
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
                    OwnerCustomerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyID);
                    table.ForeignKey(
                        name: "FK_Properties_Customers_OwnerCustomerID",
                        column: x => x.OwnerCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyID = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Images_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAmenities",
                columns: table => new
                {
                    PropertyAmenitiesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyID = table.Column<int>(type: "INTEGER", nullable: false),
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
                    table.PrimaryKey("PK_PropertyAmenities", x => x.PropertyAmenitiesID);
                    table.ForeignKey(
                        name: "FK_PropertyAmenities_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalContracts",
                columns: table => new
                {
                    RentalContractID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerCustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    TenantCustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyID = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractTerms = table.Column<string>(type: "TEXT", nullable: false),
                    RentalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DepositPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsFinalized = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalContracts", x => x.RentalContractID);
                    table.ForeignKey(
                        name: "FK_RentalContracts_Customers_OwnerCustomerID",
                        column: x => x.OwnerCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalContracts_Customers_TenantCustomerID",
                        column: x => x.TenantCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalContracts_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesContracts",
                columns: table => new
                {
                    SalesContractID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerCustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyerCustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyID = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractTerms = table.Column<string>(type: "TEXT", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsFinalized = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesContracts", x => x.SalesContractID);
                    table.ForeignKey(
                        name: "FK_SalesContracts_Customers_BuyerCustomerID",
                        column: x => x.BuyerCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesContracts_Customers_OwnerCustomerID",
                        column: x => x.OwnerCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesContracts_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "ContactAddress", "Email", "Name", "Password", "Phone", "PostalCode" },
                values: new object[,]
                {
                    { 1, "1580 B St, West Vancouver, BC, Canada", "customer1@example.com", "John Smith", "Password123!", "827-383-2545", "V9P8L6" },
                    { 2, "159 K St, Vancouver, BC, Canada", "customer2@example.com", "Emily Johnson", "Password123!", "777-839-4397", "V7M3R6" },
                    { 3, "8846 D St, Delta, BC, Canada", "customer3@example.com", "Michael Williams", "Password123!", "981-572-3074", "V7B1I7" },
                    { 4, "6552 R St, New Westminster, BC, Canada", "customer4@example.com", "Sarah Brown", "Password123!", "109-986-6177", "V8D9E6" },
                    { 5, "6957 D St, North Vancouver, BC, Canada", "customer5@example.com", "David Miller", "Password123!", "599-936-1292", "V5K3Z3" },
                    { 6, "6621 M St, Langley, BC, Canada", "customer6@example.com", "Jessica Davis", "Password123!", "185-653-7655", "V7M3W2" },
                    { 7, "4494 P St, Richmond, BC, Canada", "customer7@example.com", "James Wilson", "Password123!", "840-736-4269", "V9B6O4" },
                    { 8, "9084 E St, West Vancouver, BC, Canada", "customer8@example.com", "Laura Martinez", "Password123!", "764-993-5958", "V8Z4L5" },
                    { 9, "7654 H St, Vancouver, BC, Canada", "customer9@example.com", "Robert Anderson", "Password123!", "946-591-6741", "V2U6W5" },
                    { 10, "1565 I St, Vancouver, BC, Canada", "customer10@example.com", "Sophia Thomas", "Password123!", "190-675-6167", "V7A1K2" },
                    { 11, "2556 W St, Langley, BC, Canada", "customer11@example.com", "Daniel Taylor", "Password123!", "664-864-6435", "V2E2P3" },
                    { 12, "5220 E St, Vancouver, BC, Canada", "customer12@example.com", "Olivia Moore", "Password123!", "933-149-5858", "V3G3T6" },
                    { 13, "9561 T St, Vancouver, BC, Canada", "customer13@example.com", "Matthew Jackson", "Password123!", "325-402-5943", "V1N8M7" },
                    { 14, "8281 R St, North Vancouver, BC, Canada", "customer14@example.com", "Isabella White", "Password123!", "481-836-6170", "V9Y4H8" },
                    { 15, "1552 V St, Langley, BC, Canada", "customer15@example.com", "Christopher Harris", "Password123!", "134-688-7724", "V5S8M1" },
                    { 16, "5004 M St, Coquitlam, BC, Canada", "customer16@example.com", "Emma Martin", "Password123!", "789-687-7689", "V2Q8H1" },
                    { 17, "9310 B St, New Westminster, BC, Canada", "customer17@example.com", "Joshua Thompson", "Password123!", "902-873-9618", "V8G1I7" },
                    { 18, "8958 H St, West Vancouver, BC, Canada", "customer18@example.com", "Ava Garcia", "Password123!", "377-700-8288", "V3F1G7" },
                    { 19, "1798 J St, Langley, BC, Canada", "customer19@example.com", "Andrew Lee", "Password123!", "257-456-9090", "V6B1V1" },
                    { 20, "2104 P St, North Vancouver, BC, Canada", "customer20@example.com", "Mia Robinson", "Password123!", "301-676-6805", "V6T3K9" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "Bathrooms", "Bedrooms", "BuildYear", "City", "Country", "CurrentStatus", "Description", "ListingDate", "OwnerCustomerID", "PostalCode", "PropertyAddress", "PropertyType", "Province", "RentalPrice", "SellingPrice", "SizeOfHouse" },
                values: new object[,]
                {
                    { 1, 1, 4, 2022, "Richmond", "Canada", "Rented", "Beautiful Duplex in a great neighborhood. Built in 2014.", new DateTime(2025, 3, 14, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(1620), 11, "V1B8V3", "6122 O Ave", "Condo", "BC", 2560m, null, 3315.0 },
                    { 2, 3, 3, 2009, "Vancouver", "Canada", "Sold", "Beautiful Condo in a great neighborhood. Built in 2008.", new DateTime(2025, 3, 12, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2500), 1, "V4D8L7", "8806 E Ave", "Apartment", "BC", null, 503405m, 1107.0 },
                    { 3, 4, 4, 2019, "New Westminster", "Canada", "For Rent", "Beautiful Townhouse in a great neighborhood. Built in 2020.", new DateTime(2025, 3, 10, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2510), 4, "V4W7L1", "4501 Y Ave", "Townhouse", "BC", 3264m, null, 3596.0 },
                    { 4, 2, 4, 1984, "North Vancouver", "Canada", "Sold", "Beautiful Duplex in a great neighborhood. Built in 2019.", new DateTime(2025, 3, 13, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2520), 14, "V7Y9R6", "8645 R Ave", "House", "BC", null, 755236m, 3679.0 },
                    { 5, 2, 1, 2021, "Richmond", "Canada", "For Rent", "Beautiful Townhouse in a great neighborhood. Built in 1986.", new DateTime(2025, 2, 24, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2530), 13, "V7R1P6", "2477 T Ave", "Townhouse", "BC", 2217m, null, 1368.0 },
                    { 6, 3, 3, 1992, "West Vancouver", "Canada", "Sold", "Beautiful Duplex in a great neighborhood. Built in 2010.", new DateTime(2025, 2, 24, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2530), 15, "V3G5S8", "6199 M Ave", "Condo", "BC", null, 767165m, 3623.0 },
                    { 7, 4, 3, 2018, "Surrey", "Canada", "For Sale", "Beautiful Townhouse in a great neighborhood. Built in 2014.", new DateTime(2025, 2, 27, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2540), 2, "V5M6O5", "2066 Q Ave", "Townhouse", "BC", null, 604733m, 4971.0 },
                    { 8, 2, 2, 1992, "Coquitlam", "Canada", "For Sale", "Beautiful Apartment in a great neighborhood. Built in 1985.", new DateTime(2025, 3, 9, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2560), 13, "V8G2G3", "9332 G Ave", "Townhouse", "BC", null, 1835123m, 1986.0 },
                    { 9, 2, 5, 2012, "Vancouver", "Canada", "For Sale", "Beautiful Apartment in a great neighborhood. Built in 1997.", new DateTime(2025, 3, 16, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2560), 1, "V4J7Q2", "8773 W Ave", "Townhouse", "BC", null, 582731m, 1976.0 },
                    { 10, 1, 3, 1983, "Coquitlam", "Canada", "Rented", "Beautiful Apartment in a great neighborhood. Built in 2000.", new DateTime(2025, 3, 8, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2570), 19, "V6H8N5", "7649 T Ave", "Condo", "BC", 4626m, null, 4202.0 },
                    { 11, 1, 2, 1984, "Langley", "Canada", "For Rent", "Beautiful Townhouse in a great neighborhood. Built in 2000.", new DateTime(2025, 3, 16, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2580), 18, "V7C4X7", "4015 F Ave", "Townhouse", "BC", 1584m, null, 3630.0 },
                    { 12, 2, 1, 2003, "North Vancouver", "Canada", "Rented", "Beautiful Apartment in a great neighborhood. Built in 2011.", new DateTime(2025, 3, 7, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2580), 13, "V2F6O5", "7468 N Ave", "Condo", "BC", 3149m, null, 3644.0 },
                    { 13, 4, 5, 1999, "Burnaby", "Canada", "Rented", "Beautiful House in a great neighborhood. Built in 2002.", new DateTime(2025, 2, 28, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2590), 15, "V2P4V5", "1005 W Ave", "Apartment", "BC", 3880m, null, 1848.0 },
                    { 14, 3, 2, 2014, "North Vancouver", "Canada", "Rented", "Beautiful Duplex in a great neighborhood. Built in 2022.", new DateTime(2025, 3, 1, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2590), 11, "V6R4G9", "9916 U Ave", "Townhouse", "BC", 3156m, null, 1263.0 },
                    { 15, 4, 5, 2010, "Delta", "Canada", "Rented", "Beautiful Duplex in a great neighborhood. Built in 2022.", new DateTime(2025, 3, 14, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2600), 16, "V5H3Z2", "5072 Y Ave", "House", "BC", 4360m, null, 4347.0 },
                    { 16, 3, 1, 1994, "Vancouver", "Canada", "For Sale", "Beautiful Townhouse in a great neighborhood. Built in 2015.", new DateTime(2025, 3, 1, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2610), 13, "V1H6C1", "4302 Q Ave", "Apartment", "BC", null, 1231073m, 4557.0 },
                    { 17, 3, 3, 1994, "Delta", "Canada", "Sold", "Beautiful Duplex in a great neighborhood. Built in 2022.", new DateTime(2025, 3, 12, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2610), 13, "V9O1L4", "425 R Ave", "Townhouse", "BC", null, 571415m, 2341.0 },
                    { 18, 3, 2, 1985, "Surrey", "Canada", "Sold", "Beautiful House in a great neighborhood. Built in 2015.", new DateTime(2025, 3, 16, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2620), 2, "V8I3K5", "7181 C Ave", "House", "BC", null, 1328258m, 1780.0 },
                    { 19, 1, 4, 1990, "Burnaby", "Canada", "For Rent", "Beautiful Condo in a great neighborhood. Built in 1980.", new DateTime(2025, 3, 14, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2630), 13, "V1M1L6", "6780 D Ave", "Apartment", "BC", 2241m, null, 3845.0 },
                    { 20, 2, 3, 1984, "Richmond", "Canada", "Sold", "Beautiful Apartment in a great neighborhood. Built in 1993.", new DateTime(2025, 2, 20, 1, 31, 31, 578, DateTimeKind.Local).AddTicks(2630), 3, "V1T7I2", "8036 S Ave", "House", "BC", null, 1557945m, 3152.0 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "ContentType", "FileName", "ImageData", "PropertyID" },
                values: new object[,]
                {
                    { 1, "image/jpeg", "property_1_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 1 },
                    { 2, "image/jpeg", "property_1_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 1 },
                    { 3, "image/jpeg", "property_1_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 1 },
                    { 4, "image/jpeg", "property_2_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 2 },
                    { 5, "image/jpeg", "property_2_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 2 },
                    { 6, "image/jpeg", "property_2_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 2 },
                    { 7, "image/jpeg", "property_3_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 3 },
                    { 8, "image/jpeg", "property_3_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 3 },
                    { 9, "image/jpeg", "property_3_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 3 },
                    { 10, "image/jpeg", "property_4_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 4 },
                    { 11, "image/jpeg", "property_4_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 4 },
                    { 12, "image/jpeg", "property_4_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 4 },
                    { 13, "image/jpeg", "property_5_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 5 },
                    { 14, "image/jpeg", "property_5_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 5 },
                    { 15, "image/jpeg", "property_5_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 5 },
                    { 16, "image/jpeg", "property_6_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 6 },
                    { 17, "image/jpeg", "property_6_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 6 },
                    { 18, "image/jpeg", "property_6_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 6 },
                    { 19, "image/jpeg", "property_7_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 7 },
                    { 20, "image/jpeg", "property_7_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 7 },
                    { 21, "image/jpeg", "property_7_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 7 },
                    { 22, "image/jpeg", "property_8_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 8 },
                    { 23, "image/jpeg", "property_8_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 8 },
                    { 24, "image/jpeg", "property_8_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 8 },
                    { 25, "image/jpeg", "property_9_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 9 },
                    { 26, "image/jpeg", "property_9_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 9 },
                    { 27, "image/jpeg", "property_9_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 9 },
                    { 28, "image/jpeg", "property_10_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 10 },
                    { 29, "image/jpeg", "property_10_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 10 },
                    { 30, "image/jpeg", "property_10_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 10 },
                    { 31, "image/jpeg", "property_11_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 11 },
                    { 32, "image/jpeg", "property_11_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 11 },
                    { 33, "image/jpeg", "property_11_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 11 },
                    { 34, "image/jpeg", "property_12_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 12 },
                    { 35, "image/jpeg", "property_12_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 12 },
                    { 36, "image/jpeg", "property_12_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 12 },
                    { 37, "image/jpeg", "property_13_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 13 },
                    { 38, "image/jpeg", "property_13_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 13 },
                    { 39, "image/jpeg", "property_13_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 13 },
                    { 40, "image/jpeg", "property_14_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 14 },
                    { 41, "image/jpeg", "property_14_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 14 },
                    { 42, "image/jpeg", "property_14_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 14 },
                    { 43, "image/jpeg", "property_15_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 15 },
                    { 44, "image/jpeg", "property_15_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 15 },
                    { 45, "image/jpeg", "property_15_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 15 },
                    { 46, "image/jpeg", "property_16_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 16 },
                    { 47, "image/jpeg", "property_16_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 16 },
                    { 48, "image/jpeg", "property_16_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 16 },
                    { 49, "image/jpeg", "property_17_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 17 },
                    { 50, "image/jpeg", "property_17_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 17 },
                    { 51, "image/jpeg", "property_17_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 17 },
                    { 52, "image/jpeg", "property_18_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 18 },
                    { 53, "image/jpeg", "property_18_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 18 },
                    { 54, "image/jpeg", "property_18_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 18 },
                    { 55, "image/jpeg", "property_19_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 19 },
                    { 56, "image/jpeg", "property_19_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 19 },
                    { 57, "image/jpeg", "property_19_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 19 },
                    { 58, "image/jpeg", "property_20_image_2.jpg", new byte[] { 255, 216, 255, 224 }, 20 },
                    { 59, "image/jpeg", "property_20_image_3.jpg", new byte[] { 255, 216, 255, 224 }, 20 },
                    { 60, "image/jpeg", "property_20_image_1.jpg", new byte[] { 255, 216, 255, 224 }, 20 }
                });

            migrationBuilder.InsertData(
                table: "PropertyAmenities",
                columns: new[] { "PropertyAmenitiesID", "AirConditioning", "Cooktop", "Dishwasher", "Dryer", "Elevator", "FireSprinklerSystem", "FitnessRoom", "Heating", "Locker", "Microwave", "OtherAmenities", "ParkingLot", "PetFriendly", "PropertyID", "Refrigerator", "SecuritySystem", "SwimmingPool", "Washer" },
                values: new object[,]
                {
                    { 1, false, false, false, true, false, true, true, true, true, true, "Close to public transport, shopping center nearby", false, false, 1, true, false, true, false },
                    { 2, true, true, true, true, false, false, false, true, false, false, "Close to public transport, shopping center nearby", false, false, 2, true, true, false, false },
                    { 3, true, false, true, true, true, true, true, true, true, false, "", false, false, 3, true, false, false, true },
                    { 4, true, true, true, true, false, true, false, false, true, true, "", true, true, 4, true, true, true, true },
                    { 5, true, false, false, false, false, false, false, true, false, false, "", false, true, 5, false, false, true, true },
                    { 6, false, false, false, true, false, true, false, true, true, true, "", false, true, 6, false, false, false, false },
                    { 7, false, true, true, false, false, true, false, true, true, true, "Close to public transport, shopping center nearby", true, true, 7, false, true, false, true },
                    { 8, true, true, true, false, false, true, true, true, false, false, "Close to public transport, shopping center nearby", false, false, 8, true, false, false, true },
                    { 9, false, false, false, false, true, true, true, false, true, true, "Close to public transport, shopping center nearby", false, false, 9, true, false, false, true },
                    { 10, false, false, false, true, true, true, false, true, true, true, "", true, false, 10, true, true, true, true },
                    { 11, false, false, true, false, true, false, true, true, true, true, "", false, true, 11, true, true, false, true },
                    { 12, true, true, false, true, true, false, true, true, false, true, "Close to public transport, shopping center nearby", true, true, 12, true, true, true, true },
                    { 13, true, false, false, true, false, false, false, false, true, false, "", false, false, 13, false, false, false, false },
                    { 14, false, true, false, false, true, false, true, true, false, true, "", true, false, 14, true, false, false, false },
                    { 15, false, true, true, true, true, true, false, true, true, true, "Close to public transport, shopping center nearby", false, false, 15, false, true, false, false },
                    { 16, false, false, true, false, false, false, false, true, false, false, "Close to public transport, shopping center nearby", false, false, 16, true, false, true, false },
                    { 17, true, false, true, false, false, false, true, true, true, true, "Close to public transport, shopping center nearby", true, true, 17, true, true, true, false },
                    { 18, true, true, false, true, true, true, true, false, false, true, "Close to public transport, shopping center nearby", false, false, 18, true, true, false, false },
                    { 19, true, false, true, true, true, true, false, true, true, false, "", false, true, 19, false, true, true, true },
                    { 20, false, true, false, false, true, true, false, true, true, false, "", true, false, 20, false, true, false, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_PropertyID",
                table: "Images",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerCustomerID",
                table: "Properties",
                column: "OwnerCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAmenities_PropertyID",
                table: "PropertyAmenities",
                column: "PropertyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_OwnerCustomerID",
                table: "RentalContracts",
                column: "OwnerCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_PropertyID",
                table: "RentalContracts",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_TenantCustomerID",
                table: "RentalContracts",
                column: "TenantCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesContracts_BuyerCustomerID",
                table: "SalesContracts",
                column: "BuyerCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesContracts_OwnerCustomerID",
                table: "SalesContracts",
                column: "OwnerCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesContracts_PropertyID",
                table: "SalesContracts",
                column: "PropertyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "PropertyAmenities");

            migrationBuilder.DropTable(
                name: "RentalContracts");

            migrationBuilder.DropTable(
                name: "SalesContracts");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
