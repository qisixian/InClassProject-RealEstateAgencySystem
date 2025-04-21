using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateAgencySystem.Migrations
{
    /// <inheritdoc />
    public partial class removeNotNullconstraintForOtherAmenities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OtherAmenities",
                table: "PropertyAmenities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OtherAmenities",
                table: "PropertyAmenities",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
