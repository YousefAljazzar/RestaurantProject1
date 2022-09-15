using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RestaurantProject1.Models
{
    public partial class Customerorder
    {
        
        public int id { get; set; }
        public int CustmerId { get; set; }
        public int MealId { get; set; }

        public int CustmerOrderQuntity { get; set; }

        public virtual Customer Custmer { get; set; }
        public virtual Restaurantmenu Meal { get; set; }

    }
}
