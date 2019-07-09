using Microsoft.EntityFrameworkCore.Migrations;

namespace FUnight.Migrations
{
    public partial class adjustedActivitiesmodelfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTypes_Activities_FUnActivityId",
                table: "ActivityTypes");

            migrationBuilder.DropIndex(
                name: "IX_ActivityTypes_FUnActivityId",
                table: "ActivityTypes");

            migrationBuilder.DropColumn(
                name: "FUnActivityId",
                table: "ActivityTypes");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityTypes_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityTypes_ActivityTypeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityTypeId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "FUnActivityId",
                table: "ActivityTypes",
                nullable: true);

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
        }
    }
}
