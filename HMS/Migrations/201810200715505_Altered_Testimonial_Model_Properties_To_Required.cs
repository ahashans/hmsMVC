namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Altered_Testimonial_Model_Properties_To_Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Testimonials", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Testimonials", "Designation", c => c.String(nullable: false));
            AlterColumn("dbo.Testimonials", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Testimonials", "Message", c => c.String());
            AlterColumn("dbo.Testimonials", "Designation", c => c.String());
            AlterColumn("dbo.Testimonials", "Name", c => c.String());
        }
    }
}
