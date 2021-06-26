namespace HealthcarePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proposals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 250),
                        ZipCode = c.String(nullable: false, maxLength: 6),
                        ProposalEffectiveDate = c.DateTime(nullable: false),
                        NumberOfEmployee = c.Int(nullable: false),
                        AdminUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AdminUserId, cascadeDelete: true)
                .Index(t => t.AdminUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proposals", "AdminUserId", "dbo.Users");
            DropIndex("dbo.Proposals", new[] { "AdminUserId" });
            DropTable("dbo.Proposals");
        }
    }
}
