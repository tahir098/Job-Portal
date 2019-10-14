using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class addingDateTimeNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "38a48092-9a19-42b7-84d9-0119bea3e3c1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "41148758-b02d-4a2b-be54-81b0fa547bc1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
