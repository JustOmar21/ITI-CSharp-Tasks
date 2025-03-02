namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedReserveV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "PaymentType", c => c.String());
            AlterColumn("dbo.Reservations", "CardType", c => c.String());
            AlterColumn("dbo.Reservations", "CardNumber", c => c.String());
            AlterColumn("dbo.Reservations", "CardExp", c => c.String());
            AlterColumn("dbo.Reservations", "CardCvc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "CardCvc", c => c.String(maxLength: 10));
            AlterColumn("dbo.Reservations", "CardExp", c => c.String(maxLength: 50));
            AlterColumn("dbo.Reservations", "CardNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.Reservations", "CardType", c => c.String(maxLength: 10));
            AlterColumn("dbo.Reservations", "PaymentType", c => c.String(maxLength: 10));
        }
    }
}
