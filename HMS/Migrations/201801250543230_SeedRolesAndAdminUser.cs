namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRolesAndAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'73902f44-c8d2-497c-88f1-eb6d440d3e68', N'Admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b21bdb65-413a-437f-94bc-e741a3cd31bf', N'Doctor')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd50f40ad-2fa5-4f6e-9095-01cc08d38c00', N'Patient')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2b0f54a7-8cad-4009-a9ae-c3432fdf1843', N'Receptionist')

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName], [Gender], [DateOfBirth], [Address], [Mobile]) VALUES (N'2e0602e9-d083-42c4-b9ec-b86cf88d4656', N'ahashans@gmail.com', 0, N'AJtinvQTuE3dT4625xZeEphMHxGTdzP7Xfi0RZYSiXBjv70bUeRxbTvv6gDMjEXyOA==', N'beb11ec4-9c8f-4a51-b34e-1af64ce26bd2', NULL, 0, 0, NULL, 1, 0, N'ahashans@gmail.com', N'Ahashan Alam', N'Male', N'1995-09-09 00:00:00', N'Jatrabari, Dhaka', N'01826676706')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e0602e9-d083-42c4-b9ec-b86cf88d4656', N'73902f44-c8d2-497c-88f1-eb6d440d3e68')                
            ");
        }
        
        public override void Down()
        {
            Sql(@"
                DELETE FROM [dbo].[AspNetUserRoles] WHERE [UserId] = N'2e0602e9-d083-42c4-b9ec-b86cf88d4656'

                DELETE FROM [dbo].[AspNetRoles] WHERE [Id] = N'73902f44-c8d2-497c-88f1-eb6d440d3e68'
                DELETE FROM [dbo].[AspNetRoles] WHERE [Id] = N'b21bdb65-413a-437f-94bc-e741a3cd31bf'
                DELETE FROM [dbo].[AspNetRoles] WHERE [Id] = N'd50f40ad-2fa5-4f6e-9095-01cc08d38c00'
                DELETE FROM [dbo].[AspNetRoles] WHERE [Id] = N'2b0f54a7-8cad-4009-a9ae-c3432fdf1843'

                DELETE FROM [dbo].[AspNetUsers] WHERE [Id] = N'2e0602e9-d083-42c4-b9ec-b86cf88d4656'
            ");
        }
    }
}
