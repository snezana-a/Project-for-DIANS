namespace MVC_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCoffeController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoffeeBars", "ImageUrl", c => c.String());
            DropColumn("dbo.CoffeeBars", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CoffeeBars", "Url", c => c.String());
            DropColumn("dbo.CoffeeBars", "ImageUrl");
        }
    }
}
