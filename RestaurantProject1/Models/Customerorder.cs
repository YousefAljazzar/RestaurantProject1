using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantProject1.Models
{
    public partial class Customerorder
    {
        public int CustmerId { get; set; }
        public int MealId { get; set; }
        public int Id { get; set; }
        public int CustmerOrderQuntity { get; set; }

        public virtual Customer Custmer { get; set; }
        public virtual Restaurantmenu Meal { get; set; }
    }
}
