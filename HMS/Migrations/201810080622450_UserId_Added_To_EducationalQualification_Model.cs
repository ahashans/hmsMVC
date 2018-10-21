namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId_Added_To_EducationalQualification_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EducationalQualifications", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.EducationalQualifications", "UserId");
            AddForeignKey("dbo.EducationalQualifications", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EducationalQualifications", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.EducationalQualifications", new[] { "UserId" });
            DropColumn("dbo.EducationalQualifications", "UserId");
        }
    }
}
