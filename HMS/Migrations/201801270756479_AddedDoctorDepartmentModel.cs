namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDoctorDepartmentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorDepartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        DoctorUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.DoctorUserId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DoctorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorDepartments", "DoctorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DoctorDepartments", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.DoctorDepartments", new[] { "DoctorUserId" });
            DropIndex("dbo.DoctorDepartments", new[] { "DepartmentId" });
            DropTable("dbo.DoctorDepartments");
        }
    }
}
