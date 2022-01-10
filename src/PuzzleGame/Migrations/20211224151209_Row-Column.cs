using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuzzleGame.Migrations
{
    public partial class RowColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Column",
                table: "Cell",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Cell",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column",
                table: "Cell");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Cell");
        }
    }
}
