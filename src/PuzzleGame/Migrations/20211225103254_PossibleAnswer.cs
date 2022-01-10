using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuzzleGame.Migrations
{
    public partial class PossibleAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PossibleAnswer",
                table: "Cell",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PossibleAnswer",
                table: "Cell");
        }
    }
}
