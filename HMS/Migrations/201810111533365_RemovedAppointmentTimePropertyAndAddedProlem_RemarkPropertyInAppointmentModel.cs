namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAppointmentTimePropertyAndAddedProlem_RemarkPropertyInAppointmentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            AddColumn("dbo.Appointments", "Problem", c => c.String(nullable: false));
            AddColumn("dbo.Appointments", "Remarks", c => c.String());
            AlterColumn("dbo.Appointments", "DoctorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Appointments", "AppointmentTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "AppointmentTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            AlterColumn("dbo.Appointments", "DoctorId", c => c.String(maxLength: 128));
            DropColumn("dbo.Appointments", "Remarks");
            DropColumn("dbo.Appointments", "Problem");
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers", "Id");
        }
    }
}
