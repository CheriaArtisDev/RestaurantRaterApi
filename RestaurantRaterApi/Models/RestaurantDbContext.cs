using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterApi.Models
{
    // Inheriting from DBContext to establish a database connection
    public class RestaurantDbContext : DbContext
    {
        // Uses Constructor to pass the name of the connection string "DefaultConnection" to the DbContext
        public RestaurantDbContext() : base("DefaultConnection") { }

        // Creating a property. The DbSet holds the object we are wanting to store and its name will be the table name.
        public DbSet<Restaurant> Restaurants { get; set; }

        // Creating Ratings Table
        public DbSet<Rating> Ratings { get; set; }
    }
}