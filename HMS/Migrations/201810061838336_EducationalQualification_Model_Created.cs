namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EducationalQualification_Model_Created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationalQualifications",
                c => new
                    {
                        EducationalQualificationId = c.Int(nullable: false, identity: true),
                        DegreeName = c.String(nullable: false),
                        InstituteName = c.String(nullable: false),
                        Result = c.String(nullable: false),
                        PassingYear = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EducationalQualificationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EducationalQualifications");
        }
    }
}
