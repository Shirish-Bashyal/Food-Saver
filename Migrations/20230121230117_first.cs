using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waste_Food_Management.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_buyer",
                columns: table => new
                {
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_buyer", x => x.BuyerId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_register",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_register", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_seller",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_seller", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Sale",
                columns: table => new
                {
                    sale_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sale_item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    IsCooked = table.Column<bool>(type: "bit", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Sale", x => x.sale_id);
                    table.ForeignKey(
                        name: "FK_tbl_Sale_tbl_seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "tbl_seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Book_Buy",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    sale_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Book_Buy", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_tbl_Book_Buy_tbl_buyer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "tbl_buyer",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Book_Buy_tbl_Sale_sale_id",
                        column: x => x.sale_id,
                        principalTable: "tbl_Sale",
                        principalColumn: "sale_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Book_Buy_BuyerId",
                table: "tbl_Book_Buy",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Book_Buy_sale_id",
                table: "tbl_Book_Buy",
                column: "sale_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Sale_SellerId",
                table: "tbl_Sale",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Book_Buy");

            migrationBuilder.DropTable(
                name: "tbl_register");

            migrationBuilder.DropTable(
                name: "tbl_buyer");

            migrationBuilder.DropTable(
                name: "tbl_Sale");

            migrationBuilder.DropTable(
                name: "tbl_seller");
        }
    }
}
