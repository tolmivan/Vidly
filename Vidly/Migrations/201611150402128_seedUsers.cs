namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'2d903ec6-6300-458a-8d02-59444814c47f', N'admin@vidly.com', 0, N'AC6PfDv+CxNvL0evVxv/VTzDzAe+JkwHlgZF22ybvo3W9PUfwz4e3OTuailvm80FOg==', N'62e1cfa2-7116-4186-8f8d-425c0471e4ae', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com', N'2222')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'6a113d47-aa59-484b-a485-597d2f7d6702', N'guest@vidly.com', 0, N'AAJP6e5Ia0di1KYdIcilAunSan7pHmcO3SToePNZMCfidv7fKfdXs1hSbtPT0+A4uA==', N'4aa98a07-3554-4f10-aa38-299d029c5199', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com', N'1111')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd7d3a7ae-1633-4765-a4f5-65e888e7d1ec', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d903ec6-6300-458a-8d02-59444814c47f', N'd7d3a7ae-1633-4765-a4f5-65e888e7d1ec')
");
        }
        
        public override void Down()
        {
        }
    }
}
