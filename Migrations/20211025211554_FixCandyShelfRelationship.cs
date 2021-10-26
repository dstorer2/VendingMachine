using Microsoft.EntityFrameworkCore.Migrations;

namespace VendingMachine.Migrations
{
    public partial class FixCandyShelfRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentShelf",
                table: "Candies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentShelf",
                table: "Candies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
