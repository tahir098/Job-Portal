using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class removingEmployerRequiredField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Users_EmployerId",
                table: "Job");

            migrationBuilder.AlterColumn<string>(
                name: "EmployerId",
                table: "Job",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c64f4738-d308-4366-8641-f57151aa1583");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ce28846f-44d7-4162-bba4-56b43aafbb1f");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Users_EmployerId",
                table: "Job",
                column: "EmployerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Users_EmployerId",
                table: "Job");

            migrationBuilder.AlterColumn<string>(
                name: "EmployerId",
                table: "Job",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Users_EmployerId",
                table: "Job",
                column: "EmployerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
