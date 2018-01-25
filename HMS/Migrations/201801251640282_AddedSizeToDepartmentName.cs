namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSizeToDepartmentName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String());
        }
    }
}
