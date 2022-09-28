using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise_3.Migrations
{
    public partial class addcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PartyList",
                table: "PartyList");

            migrationBuilder.RenameTable(
                name: "PartyList",
                newName: "Party");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Party",
                table: "Party",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Party",
                table: "Party");

            migrationBuilder.RenameTable(
                name: "Party",
                newName: "PartyList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartyList",
                table: "PartyList",
                column: "ID");
        }
    }
}
