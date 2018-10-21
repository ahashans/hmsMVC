namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Altered_Blog_Model_Properties_To_Required_And_Added_Feature_Image_Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "FeatureImagePath", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Content", c => c.String());
            AlterColumn("dbo.Blogs", "Title", c => c.String());
            DropColumn("dbo.Blogs", "FeatureImagePath");
        }
    }
}
