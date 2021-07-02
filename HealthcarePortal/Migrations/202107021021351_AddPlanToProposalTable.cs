namespace HealthcarePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlanToProposalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proposals", "PlanId", c => c.Int(nullable: false));
            CreateIndex("dbo.Proposals", "PlanId");
            AddForeignKey("dbo.Proposals", "PlanId", "dbo.Plans", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proposals", "PlanId", "dbo.Plans");
            DropIndex("dbo.Proposals", new[] { "PlanId" });
            DropColumn("dbo.Proposals", "PlanId");
        }
    }
}
