using Microsoft.EntityFrameworkCore.Migrations;

namespace VendingMachine.Migrations
{
    public partial class AddCharIndexForShelves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShelfIndex",
                table: "Shelves",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShelfIndex",
                table: "Shelves");
        }
    }
}
