namespace HealthcarePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        DOB = c.DateTime(nullable: false),
                        ZipCode = c.String(nullable: false, maxLength: 6),
                        ProposalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proposals", t => t.ProposalId, cascadeDelete: true)
                .Index(t => t.ProposalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ProposalId", "dbo.Proposals");
            DropIndex("dbo.Employees", new[] { "ProposalId" });
            DropTable("dbo.Employees");
        }
    }
}
