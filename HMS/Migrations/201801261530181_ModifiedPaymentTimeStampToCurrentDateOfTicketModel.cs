namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedPaymentTimeStampToCurrentDateOfTicketModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "PaymentTimeStamp", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "PaymentTimeStamp", c => c.DateTime(nullable: false));
        }
    }
}
