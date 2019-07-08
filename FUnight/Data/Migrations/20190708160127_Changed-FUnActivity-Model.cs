using Microsoft.EntityFrameworkCore.Migrations;

namespace FUnight.Data.Migrations
{
    public partial class ChangedFUnActivityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityTypes_ActivityTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityType_Id",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ApplicationUser_Id",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UserGroup_Id",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser_Id",
                table: "UserGroups",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserGroup_Id",
                table: "AspNetUsers",
                newName: "UserGroupId");

            migrationBuilder.AlterColumn<int>(
                name: "UserGroupId",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityTypeId",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "ApplicationUserId", "FUnActivityId", "Name" },
                values: new object[] { 2, 0, null, "Cohort 1" });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "ApplicationUserId", "FUnActivityId", "Name" },
                values: new object[] { 3, 0, null, "lunchtime D&D" });

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityTypes_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Activities_ActivityTypes_ActivityTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities");

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "UserGroups",
                newName: "ApplicationUser_Id");

            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "AspNetUsers",
                newName: "UserGroup_Id");

            migrationBuilder.AlterColumn<int>(
                name: "UserGroupId",
                table: "Activities",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ActivityTypeId",
                table: "Activities",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ActivityType_Id",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser_Id",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserGroup_Id",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityTypes_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
