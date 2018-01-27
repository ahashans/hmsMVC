namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiagnosisModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        DiagnosisId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        DoctorUserId = c.String(nullable: false, maxLength: 128),
                        DiagnosisProvided = c.String(nullable: false, maxLength: 1000),
                        TreatmentProvided = c.String(nullable: false, maxLength: 1000),
                        RequiredTests = c.String(nullable: false, maxLength: 1000),
                        DiagnosisTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DiagnosisId)
                .ForeignKey("dbo.AspNetUsers", t => t.DoctorUserId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId)
                .Index(t => t.TicketId)
                .Index(t => t.DoctorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diagnosis", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Diagnosis", "DoctorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Diagnosis", new[] { "DoctorUserId" });
            DropIndex("dbo.Diagnosis", new[] { "TicketId" });
            DropTable("dbo.Diagnosis");
        }
    }
}
