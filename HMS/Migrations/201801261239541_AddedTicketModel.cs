namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTicketModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        BillAmount = c.Int(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        PaymentTimeStamp = c.DateTime(nullable: false),
                        TicketStatus = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        PatientUserId = c.String(nullable: false, maxLength: 128),
                        ReceptionistUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientUserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceptionistUserId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PatientUserId)
                .Index(t => t.ReceptionistUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ReceptionistUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "PatientUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Tickets", new[] { "ReceptionistUserId" });
            DropIndex("dbo.Tickets", new[] { "PatientUserId" });
            DropIndex("dbo.Tickets", new[] { "DepartmentId" });
            DropTable("dbo.Tickets");
        }
    }
}
