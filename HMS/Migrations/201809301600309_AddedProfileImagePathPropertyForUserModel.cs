namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProfileImagePathPropertyForUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfileImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfileImagePath");
        }
    }
}
