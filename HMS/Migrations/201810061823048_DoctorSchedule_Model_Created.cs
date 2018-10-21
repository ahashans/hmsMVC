namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorSchedule_Model_Created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorSchedules",
                c => new
                    {
                        DoctorScheduleId = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        DayOfWeek = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorScheduleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DoctorSchedules");
        }
    }
}
