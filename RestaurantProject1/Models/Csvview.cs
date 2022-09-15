using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantProject1.Models
{
    public partial class Csvview
    {
        public string RestaurantName { get; set; }
        public decimal? NumberOfOrderedCustomer { get; set; }
        public decimal? ProfitInUsd { get; set; }
        public decimal? ProfitInNis { get; set; }
        public string TheBestSellingMeal { get; set; }
        public string MostPurchasedCustomer { get; set; }
    }
}
