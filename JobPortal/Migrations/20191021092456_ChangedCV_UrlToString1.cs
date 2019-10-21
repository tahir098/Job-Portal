using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class ChangedCV_UrlToString1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d9072738-902a-4e93-ac37-1201434c9be6");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a9509c59-8726-4a0a-ad7d-c127bd0fad7c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6ad16c97-8e65-4594-b2e4-ad1e1bb41498");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "64d0cbdf-8adb-4c72-a2ee-0a7e753b1f2d");
        }
    }
}
