namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Image_Path_To_Event_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "FeatureImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "FeatureImagePath");
        }
    }
}
