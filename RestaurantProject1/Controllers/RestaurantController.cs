using Microsoft.AspNetCore.Mvc;
using RestaurantProject1.Models;
using RestaurantProject1.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private restaurantdbContext _restaurantdbContext;
        public RestaurantController(restaurantdbContext r)
        {
            _restaurantdbContext = r;
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            var restrentList = _restaurantdbContext.Restaurants.ToList();

            return restrentList;
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resturent = _restaurantdbContext.Restaurants.Find(id);
            if (resturent == null)
            {
                return BadRequest("Invalied");
            }

            return Ok(resturent);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult Post([FromBody] RestaurantViewModel restaurant)
        {
            Restaurant newRestaurant = new()
            {
                Name = restaurant.Name.ToTitleCase(),

                PhoneNumber = restaurant.PhoneNumber

            };

            _restaurantdbContext.Restaurants.Add(newRestaurant);
            _restaurantdbContext.SaveChanges();

            return Ok(newRestaurant);


        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RestaurantViewModel restaurantView)
        {
            var restaurant = _restaurantdbContext.Restaurants
                                                 .Find(id);


            restaurant.PhoneNumber = restaurantView.PhoneNumber;
            restaurant.Name = restaurantView.Name.ToTitleCase();

            _restaurantdbContext.Restaurants.Update(restaurant);
            _restaurantdbContext.SaveChanges();

        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resturent = _restaurantdbContext.Restaurants.Find(id);
            if (resturent == null)
            {
                return BadRequest("Invalied");
            }

            resturent.Archived = true;
            _restaurantdbContext.SaveChanges();
            return Ok(resturent);

        }
    }
}
