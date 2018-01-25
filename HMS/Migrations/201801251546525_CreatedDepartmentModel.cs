namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDepartmentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Guid(nullable: false),
                        Name = c.String(),
                        Fee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departments");
        }
    }
}
