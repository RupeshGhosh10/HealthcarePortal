namespace HealthcarePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleTableColumnRename : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserRoles", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.UserRoles", name: "Role_Id", newName: "RoleId");
            RenameIndex(table: "dbo.UserRoles", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserRoles", name: "IX_Role_Id", newName: "IX_RoleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserRoles", name: "IX_RoleId", newName: "IX_Role_Id");
            RenameIndex(table: "dbo.UserRoles", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.UserRoles", name: "RoleId", newName: "Role_Id");
            RenameColumn(table: "dbo.UserRoles", name: "UserId", newName: "User_Id");
        }
    }
}
