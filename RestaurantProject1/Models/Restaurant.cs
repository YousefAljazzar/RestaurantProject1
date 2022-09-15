using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RestaurantProject1.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Restaurantmenus = new HashSet<Restaurantmenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool Archived { get; set; }

        [Timestamp]
        public DateTime CreatedDateUTC { get; set; }


        [Timestamp]
        public DateTime UpdatedDateUTC { get; set; }
        public virtual ICollection<Restaurantmenu> Restaurantmenus { get; set; }
    }
}
