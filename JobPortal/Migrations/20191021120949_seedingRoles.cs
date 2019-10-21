using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class seedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "fa8aadfe-6b52-4301-a84a-99149dd6e010", "Employer", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "b7b12702-3d0c-4516-bda0-d9061d53d069", "Applicant", null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "df6c29e1-4c3a-457a-a5d4-f9af03f7fb94", "1" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c4b40680-1783-4eaa-9467-76b347e4b061", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c4b40680-1783-4eaa-9467-76b347e4b061", "2" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "df6c29e1-4c3a-457a-a5d4-f9af03f7fb94", "1" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2");
        }
    }
}
