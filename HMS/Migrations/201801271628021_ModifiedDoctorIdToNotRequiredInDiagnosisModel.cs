namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDoctorIdToNotRequiredInDiagnosisModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Diagnosis", "DoctorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Diagnosis", new[] { "DoctorUserId" });
            AlterColumn("dbo.Diagnosis", "DoctorUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Diagnosis", "DoctorUserId");
            AddForeignKey("dbo.Diagnosis", "DoctorUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diagnosis", "DoctorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Diagnosis", new[] { "DoctorUserId" });
            AlterColumn("dbo.Diagnosis", "DoctorUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Diagnosis", "DoctorUserId");
            AddForeignKey("dbo.Diagnosis", "DoctorUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
