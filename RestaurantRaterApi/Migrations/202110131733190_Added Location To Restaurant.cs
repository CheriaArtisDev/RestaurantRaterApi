namespace RestaurantRaterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocationToRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Location");
        }
    }
}
