namespace MVC_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CoffeeBars", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AddToFavourites", "BarName", c => c.String(nullable: false));
            AlterColumn("dbo.AddToFavourites", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.AddToFavourites", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddToFavourites", "UserId", c => c.String());
            AlterColumn("dbo.AddToFavourites", "UserName", c => c.String());
            AlterColumn("dbo.AddToFavourites", "BarName", c => c.String());
            AlterColumn("dbo.CoffeeBars", "Name", c => c.String());
        }
    }
}
