namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Frontends",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Kitchens",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        BirthDay = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false),
                        NumberGuest = c.Int(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        AptSuite = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false, maxLength: 50),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        RoomType = c.String(nullable: false, maxLength: 10),
                        RoomFloor = c.String(nullable: false, maxLength: 10),
                        RoomNumber = c.String(nullable: false, maxLength: 10),
                        TotalBill = c.Double(nullable: false),
                        PaymentType = c.String(nullable: false, maxLength: 10),
                        CardType = c.String(nullable: false, maxLength: 10),
                        CardNumber = c.String(nullable: false, maxLength: 50),
                        CardExp = c.String(nullable: false, maxLength: 50),
                        CardCvc = c.String(nullable: false, maxLength: 10),
                        ArrivalTime = c.DateTime(nullable: false),
                        LeavingTime = c.DateTime(nullable: false),
                        CheckIn = c.Boolean(nullable: false),
                        BreakFast = c.Int(nullable: false),
                        Lunch = c.Int(nullable: false),
                        Dinner = c.Int(nullable: false),
                        Cleaning = c.Boolean(nullable: false),
                        Towel = c.Boolean(nullable: false),
                        SSurprise = c.Boolean(nullable: false),
                        SupplyStatus = c.Boolean(nullable: false),
                        FoodBill = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservations");
            DropTable("dbo.Kitchens");
            DropTable("dbo.Frontends");
        }
    }
}
