namespace HealthcarePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Users] ON
                INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [MobileNumber], [Password], [Address]) VALUES (1, N'Rupesh', N'Ghosh', N'rupeshghosh10@gmail.com', N'8837882509', N'Rupesh Ghosh', NULL)
                SET IDENTITY_INSERT [dbo].[Users] OFF");

            Sql(@"SET IDENTITY_INSERT [dbo].[Roles] ON
                INSERT INTO [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'Admin')
                INSERT INTO [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'Sales')
                SET IDENTITY_INSERT [dbo].[Roles] OFF");

            Sql(@"INSERT INTO [dbo].[UserRoles] ([User_Id], [Role_Id]) VALUES (1, 1)");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM [dbo].[Users] WHERE [Id] == 1");

            Sql(@"DELETE FROM [dbo].[Roles] WHERE [Id] == 1");
            Sql(@"DELETE FROM [dbo].[Roles] WHERE [Id] == 2");
        }
    }
}
