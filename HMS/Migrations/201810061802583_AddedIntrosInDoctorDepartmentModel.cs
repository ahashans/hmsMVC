namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIntrosInDoctorDepartmentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorDepartments", "ShortIntro", c => c.String());
            AddColumn("dbo.DoctorDepartments", "LongIntro", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorDepartments", "LongIntro");
            DropColumn("dbo.DoctorDepartments", "ShortIntro");
        }
    }
}
