namespace Restapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodTypeRestaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdFoodType = c.Int(nullable: false),
                        IdRestaurant = c.Int(nullable: false),
                        FoodType_Id = c.Int(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodTypes", t => t.FoodType_Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.FoodType_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Description = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Description = c.String(maxLength: 1024),
                        Phone = c.String(maxLength: 16),
                        IdRestaurantType = c.Int(nullable: false),
                        RestaurantType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RestaurantTypes", t => t.RestaurantType_Id)
                .Index(t => t.RestaurantType_Id);
            
            CreateTable(
                "dbo.RestaurantTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Description = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RatingRestaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdRestaurant = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.RestaurantBranches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        IdRestaurant = c.Int(nullable: false),
                        IdLocation = c.Int(nullable: false),
                        Phone = c.String(maxLength: 16),
                        Location_Id = c.Int(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Restaurant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantBranches", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantBranches", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.RatingRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.FoodTypeRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "RestaurantType_Id", "dbo.RestaurantTypes");
            DropForeignKey("dbo.FoodTypeRestaurants", "FoodType_Id", "dbo.FoodTypes");
            DropIndex("dbo.RestaurantBranches", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantBranches", new[] { "Location_Id" });
            DropIndex("dbo.RatingRestaurants", new[] { "Restaurant_Id" });
            DropIndex("dbo.Restaurants", new[] { "RestaurantType_Id" });
            DropIndex("dbo.FoodTypeRestaurants", new[] { "Restaurant_Id" });
            DropIndex("dbo.FoodTypeRestaurants", new[] { "FoodType_Id" });
            DropTable("dbo.RestaurantBranches");
            DropTable("dbo.RatingRestaurants");
            DropTable("dbo.Locations");
            DropTable("dbo.RestaurantTypes");
            DropTable("dbo.Restaurants");
            DropTable("dbo.FoodTypes");
            DropTable("dbo.FoodTypeRestaurants");
        }
    }
}
