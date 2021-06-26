namespace HealthcarePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlansTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlanName = c.String(nullable: false, maxLength: 100),
                        SumInsured = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Plans");
        }
    }
}
