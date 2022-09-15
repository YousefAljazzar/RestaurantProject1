using RestaurantProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject1.Utility
{
    public static class Helper
    {

        public static bool isAvailable(int id, restaurantdbContext _restaurantdbContext)
        {
            var resturantMenu = _restaurantdbContext.Restaurantmenus.Find(id);
            if (resturantMenu.Quantity > 0)
            {
                return true;
            }
            return false;
        }
    }
}
