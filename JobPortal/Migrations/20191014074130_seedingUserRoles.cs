using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class seedingUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3b655f8d-0ac8-4fea-be17-13650bee9019");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2eb56ed4-be3c-4399-afbc-ab8169ee3178");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "675234c0-ae5e-43cf-8e80-f37ec7b239df", "1" },
                    { "a11491f4-02fe-43f1-86ec-25cc7d0b90de", "2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "675234c0-ae5e-43cf-8e80-f37ec7b239df", "1" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a11491f4-02fe-43f1-86ec-25cc7d0b90de", "2" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "29759ba0-6161-436d-9a2a-820b87905cfc");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2d50b7f6-8212-4b06-928b-e6556476eb8b");
        }
    }
}
