namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDescriptionPropertySetToRequiredInDepartmentModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "ShortDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "ShortDescription", c => c.String());
        }
    }
}
