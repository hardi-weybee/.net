using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise_3.Migrations
{
    public partial class addedtable3rd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignParty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    partyID = table.Column<int>(nullable: false),
                    productID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignParty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssignParty_Party_partyID",
                        column: x => x.partyID,
                        principalTable: "Party",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignParty_Product_productID",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_partyID",
                table: "AssignParty",
                column: "partyID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_productID",
                table: "AssignParty",
                column: "productID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignParty");
        }
    }
}
