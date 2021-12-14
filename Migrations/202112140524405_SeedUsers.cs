namespace Task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'27448db5-632e-4a4b-8d22-eeb1af5dd9a6', N'admin@gmail.com', 0, N'AD07C9aV9pEdwBhhy3KncYKlU5Pka65cObMjRuMHTRq7Eh0RzzToNQbvZy+EG0Zlxg==', N'27ec3743-2382-49e0-99ef-4efb31353765', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c8f60617-95fe-44fb-aa32-4552ee84dd44', N'user@gmail.com', 0, N'AMI3IkcCKjpOj9rndYFEgNTmATAAeGp3F74FaCNWhNqNT0aV531kYuZ/jhwI+AiryA==', N'17edb499-5ec3-4564-ac18-089dec437a70', NULL, 0, 0, NULL, 1, 0, N'user@gmail.com')
                    
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'380f6bbd-8293-4a78-857c-6ee9d87a23a2', N'Admin')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'27448db5-632e-4a4b-8d22-eeb1af5dd9a6', N'380f6bbd-8293-4a78-857c-6ee9d87a23a2')


             ");
        }
        
        public override void Down()
        {
        }
    }
}
