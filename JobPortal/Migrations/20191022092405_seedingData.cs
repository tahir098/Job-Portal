using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Users] ([UserId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [CV_Url]) VALUES (N'c4b40680-1783-4eaa-9467-76b347e4b061', N'abbastahir891@gmail.com', N'ABBASTAHIR891@GMAIL.COM', N'abbastahir891@gmail.com', N'ABBASTAHIR891@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEDTqQLfahnAnPmcxRkCOWDGRxyP69Z7pwAlKI0AIyc/cymeX+/R4zYzrB8sF6kHN9g==', N'XRMKK5VLB3HGHOCLDLX5VFFLWERYLRW3', N'f98ac70a-49ca-45ad-bf2d-72c26cfa2d45', NULL, 0, 0, NULL, 1, 0, N'IdentityUser', NULL)" +
                "INSERT INTO [dbo].[Users] ([UserId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [CV_Url]) VALUES (N'df6c29e1-4c3a-457a-a5d4-f9af03f7fb94', N'tahirabbasnaeem1998@gmail.com', N'TAHIRABBASNAEEM1998@GMAIL.COM', N'tahirabbasnaeem1998@gmail.com', N'TAHIRABBASNAEEM1998@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEAMdj5hg961/KfaQsuBJ82EA/tjuH1QcQBmKVtbtmbLyc4W6G1pt/7iLGRCC7U9/hQ==', N'JUFY6QFUX66K4OZABQMQNYOND7FXUM7X', N'0aa63afc-f041-42fc-b3ac-5ad6a4abb3ca', NULL, 0, 0, NULL, 1, 0, N'IdentityUser', NULL)" +
                "INSERT INTO [dbo].[Roles] ([RoleId], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Employer', NULL, N'1a39d4a8-9be6-4bf6-b2c6-0262c9f80282')" +
                "INSERT INTO [dbo].[Roles] ([RoleId], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Applicant', NULL, N'a9c8380c-ea41-4edc-81a1-7c56680a1b78')" +
                "INSERT INTO [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'df6c29e1-4c3a-457a-a5d4-f9af03f7fb94', N'1')" +
                "INSERT INTO [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'c4b40680-1783-4eaa-9467-76b347e4b061', N'2')" 
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
