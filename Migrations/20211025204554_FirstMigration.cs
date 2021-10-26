using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VendingMachine.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    ShelfId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Flavor = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.ShelfId);
                });

            migrationBuilder.CreateTable(
                name: "Wrappers",
                columns: table => new
                {
                    WrapperId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WrapperColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wrappers", x => x.WrapperId);
                });

            migrationBuilder.CreateTable(
                name: "Candies",
                columns: table => new
                {
                    CandyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    WrapperColor = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    ShelfId = table.Column<int>(nullable: false),
                    ParentShelf = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candies", x => x.CandyId);
                    table.ForeignKey(
                        name: "FK_Candies_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "ShelfId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candies_ShelfId",
                table: "Candies",
                column: "ShelfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candies");

            migrationBuilder.DropTable(
                name: "Wrappers");

            migrationBuilder.DropTable(
                name: "Shelves");
        }
    }
}
