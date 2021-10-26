using Microsoft.EntityFrameworkCore.Migrations;

namespace VendingMachine.Migrations
{
    public partial class WrappersModelQty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "Wrappers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "Wrappers");
        }
    }
}
