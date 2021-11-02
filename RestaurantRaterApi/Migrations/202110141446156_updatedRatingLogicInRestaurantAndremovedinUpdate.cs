namespace RestaurantRaterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedRatingLogicInRestaurantAndremovedinUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Rating", c => c.Double(nullable: false));
        }
    }
}
