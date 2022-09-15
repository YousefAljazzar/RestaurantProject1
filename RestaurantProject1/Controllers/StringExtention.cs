using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject1.Controllers
{
    public static class StringExtention
    {
        public static string ToTitleCase(this string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1);
           
        }
    }
}
