using Microsoft.EntityFrameworkCore.Migrations;

namespace FUnight.Migrations
{
    public partial class addedactyTypeCommenttoFUnActivityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActyTypeComment",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActyTypeComment",
                table: "Activities");
        }
    }
}
