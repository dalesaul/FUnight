using Microsoft.EntityFrameworkCore.Migrations;

namespace FUnight.Data.Migrations
{
    public partial class addedFUnActivityViewModelsandseedingdataforactytype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserGroups",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Park" },
                    { 2, "Dining Out" },
                    { 3, "BBQ at Home" },
                    { 4, "Go to Movies" },
                    { 5, "Sporting Event" },
                    { 6, "Local Event" },
                    { 7, "Ritual Sacriface" },
                    { 8, "Overthrow the Gov't" }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "ApplicationUser_Id", "Name" },
                values: new object[] { 1, 0, "MMMB group" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserGroups");
        }
    }
}
