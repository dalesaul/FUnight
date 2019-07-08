using Microsoft.EntityFrameworkCore.Migrations;

namespace FUnight.Data.Migrations
{
    public partial class updatedFUnActivityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FUnActivityId",
                table: "UserGroups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FUnActivityId",
                table: "ActivityTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_FUnActivityId",
                table: "UserGroups",
                column: "FUnActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTypes_FUnActivityId",
                table: "ActivityTypes",
                column: "FUnActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTypes_Activities_FUnActivityId",
                table: "ActivityTypes",
                column: "FUnActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Activities_FUnActivityId",
                table: "UserGroups",
                column: "FUnActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTypes_Activities_FUnActivityId",
                table: "ActivityTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Activities_FUnActivityId",
                table: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserGroups_FUnActivityId",
                table: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_ActivityTypes_FUnActivityId",
                table: "ActivityTypes");

            migrationBuilder.DropColumn(
                name: "FUnActivityId",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "FUnActivityId",
                table: "ActivityTypes");
        }
    }
}
