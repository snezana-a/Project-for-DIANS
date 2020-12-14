namespace MVC_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmodels2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NumberOfFavouriteBars", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Adress");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "NumberOfBars");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NumberOfBars", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Country", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Adress", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "NumberOfFavouriteBars");
        }
    }
}
