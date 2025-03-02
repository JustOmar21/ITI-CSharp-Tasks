namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedReserve : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "PaymentType", c => c.String(maxLength: 10));
            AlterColumn("dbo.Reservations", "CardType", c => c.String(maxLength: 10));
            AlterColumn("dbo.Reservations", "CardNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.Reservations", "CardExp", c => c.String(maxLength: 50));
            AlterColumn("dbo.Reservations", "CardCvc", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "CardCvc", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Reservations", "CardExp", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reservations", "CardNumber", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reservations", "CardType", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Reservations", "PaymentType", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
