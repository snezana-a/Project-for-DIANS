namespace MVC_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddToFavourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarName = c.String(),
                        UserName = c.String(),
                        BarId = c.Int(nullable: false),
                        UserId = c.String(),
                        selectedCoffeeBar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CoffeeBars", "AddToFavourites_Id", c => c.Int());
            AddColumn("dbo.CoffeeBars", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Adress", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Country", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumberOfBars", c => c.Int(nullable: false));
            CreateIndex("dbo.CoffeeBars", "AddToFavourites_Id");
            CreateIndex("dbo.CoffeeBars", "ApplicationUser_Id");
            AddForeignKey("dbo.CoffeeBars", "AddToFavourites_Id", "dbo.AddToFavourites", "Id");
            AddForeignKey("dbo.CoffeeBars", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoffeeBars", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CoffeeBars", "AddToFavourites_Id", "dbo.AddToFavourites");
            DropIndex("dbo.CoffeeBars", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CoffeeBars", new[] { "AddToFavourites_Id" });
            DropColumn("dbo.AspNetUsers", "NumberOfBars");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Adress");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.CoffeeBars", "ApplicationUser_Id");
            DropColumn("dbo.CoffeeBars", "AddToFavourites_Id");
            DropTable("dbo.AddToFavourites");
        }
    }
}
