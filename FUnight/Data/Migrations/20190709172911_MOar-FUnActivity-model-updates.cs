using Microsoft.EntityFrameworkCore.Migrations;

namespace FUnight.Migrations
{
    public partial class MOarFUnActivitymodelupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Activities_FUnActivityId",
                table: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserGroups_FUnActivityId",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "FUnActivityId",
                table: "UserGroups");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserGroupId",
                table: "Activities",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UserGroupId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "FUnActivityId",
                table: "UserGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_FUnActivityId",
                table: "UserGroups",
                column: "FUnActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Activities_FUnActivityId",
                table: "UserGroups",
                column: "FUnActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
