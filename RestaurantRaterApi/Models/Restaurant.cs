using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterApi.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.0, 10.0)]
        public double Rating
        {
            get
            {
                if (Ratings.Count == 0)
                {
                    return 0;
                }

                double ratingScore = 0;

                foreach (var rating in Ratings)
                {
                    ratingScore += rating.Score;
                }
                return Math.Round(ratingScore / Ratings.Count, 3);
            }
        }

        [Required]
        public string Location { get; set; }

        public bool IsRecommended
        {
            get
            {
               return Rating >= 6;
            }
        }

        // Navigation Property for our One to Many relationship with Ratings
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();


    }
}