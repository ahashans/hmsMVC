namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDescriptionPropertyAddedToDepartmentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "ShortDescription");
        }
    }
}
