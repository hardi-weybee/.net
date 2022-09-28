using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise_3.Migrations
{
    public partial class table14th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductRate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    DateOfRate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductRate_Product_productID",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_productID",
                table: "ProductRate",
                column: "productID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRate");
        }
    }
}
