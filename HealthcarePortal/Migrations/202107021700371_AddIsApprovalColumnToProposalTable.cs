namespace HealthcarePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsApprovalColumnToProposalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proposals", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proposals", "IsApproved");
        }
    }
}
