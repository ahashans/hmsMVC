namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Blog_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorId = c.String(maxLength: 128),
                        Content = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "AuthorId" });
            DropTable("dbo.Blogs");
        }
    }
}
