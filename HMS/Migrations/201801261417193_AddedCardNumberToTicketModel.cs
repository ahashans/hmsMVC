namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCardNumberToTicketModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "CardNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "CardNumber");
        }
    }
}
