using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject1.ModelViews
{
    public class RestaurantMenuModel
    {
        public int RestaurantId { get; set; }
        public string MealName { get; set; }

        public double PriceInNis { get; set; }

        public int Quantity { get; set; }
    }
}
