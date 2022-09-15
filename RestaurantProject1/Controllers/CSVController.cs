using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

         
        public CSVController(restaurantdbContext r)
        {
            _restaurantdbContext = r;

        }
        [HttpGet("~/getCSV")]
        public IActionResult ExportCSV()
        {
            var list = _restaurantdbContext.Csvviews.ToList();

                     
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            using (var writer = new StreamWriter("f://Report.csv"))
            using (var csv = new CsvWriter(writer, config))
            {       
               
                    csv.WriteRecords(list);
                    
                
                writer.Flush();
            }
            return Ok();
        }
    }
}
