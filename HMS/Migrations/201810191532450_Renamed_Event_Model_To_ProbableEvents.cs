namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renamed_Event_Model_To_ProbableEvents : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Events", newName: "ProbableEvents");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProbableEvents", newName: "Events");
        }
    }
}
