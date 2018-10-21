namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Replaced_DoctorId_With_DoctorDepartmentId_In_Appointment_Model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            AddColumn("dbo.Appointments", "DoctorDepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "DoctorDepartmentId");
            AddForeignKey("dbo.Appointments", "DoctorDepartmentId", "dbo.DoctorDepartments", "Id", cascadeDelete: true);
            DropColumn("dbo.Appointments", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DoctorId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Appointments", "DoctorDepartmentId", "dbo.DoctorDepartments");
            DropIndex("dbo.Appointments", new[] { "DoctorDepartmentId" });
            DropColumn("dbo.Appointments", "DoctorDepartmentId");
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
