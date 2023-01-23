using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waste_Food_Management.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "tbl_Sale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "tbl_Sale",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "tbl_Sale");

            migrationBuilder.DropColumn(
                name: "description",
                table: "tbl_Sale");
        }
    }
}
