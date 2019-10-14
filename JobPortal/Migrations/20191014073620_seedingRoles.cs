using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class seedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cv",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Employer_ConfirmPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Employer_Password",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "29759ba0-6161-436d-9a2a-820b87905cfc", "Employer", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "2d50b7f6-8212-4b06-928b-e6556476eb8b", "Applicant", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cv",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employer_ConfirmPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employer_Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
