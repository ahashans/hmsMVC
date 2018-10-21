namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IconCodePropertyAddedToDepartmentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "IconCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "IconCode");
        }
    }
}
