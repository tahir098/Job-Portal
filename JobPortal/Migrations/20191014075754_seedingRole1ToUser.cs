using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class seedingRole1ToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "675234c0-ae5e-43cf-8e80-f37ec7b239df", "1" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2cc1c62d-be7a-41d2-ab71-cdfd4b20c7b9");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3cabf200-1a7f-4857-8468-47010e85382c");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0d01af92-276f-4a51-85a5-574ca7e7f081", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0d01af92-276f-4a51-85a5-574ca7e7f081", "1" });

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
                values: new object[] { "675234c0-ae5e-43cf-8e80-f37ec7b239df", "1" });
        }
    }
}
