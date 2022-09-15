using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RestaurantProject1.Models
{
    public partial class Restaurantmenu
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        
        public double PriceInNis { get; set; }
        public double PriceInUsd { get; set; }
        public int Quantity { get; set; }
        public bool Archived { get; set; }
        public int RestaurantId { get; set; }
        [Timestamp]
        public DateTime CreatedDateUTC { get; set; }

        [Timestamp]
        public DateTime UpdatedDateUTC { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
