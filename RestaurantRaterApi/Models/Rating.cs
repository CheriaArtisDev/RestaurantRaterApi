using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRaterApi.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key 
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }

        // Navigation Property      // virtual is used on properties that can be overwritten to connect to                                  another table
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        [Range(0, 10)]
        public double Score { get; set; }
    }
}