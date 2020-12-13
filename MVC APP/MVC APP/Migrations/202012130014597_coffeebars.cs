namespace MVC_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coffeebars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoffeeBars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Distance = c.Single(nullable: false),
                        WebPage = c.String(),
                        Url = c.String(),
                        Location = c.String(),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CoffeeBars");
        }
    }
}
