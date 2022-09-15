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
    public class ResturantMenuController : ControllerBase
    {

        private restaurantdbContext _restaurantdbContext;

        public ResturantMenuController(restaurantdbContext r)
        {
            _restaurantdbContext = r;
        }
        // GET: api/<ResturantMenuController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _restaurantdbContext.Restaurantmenus.ToList();
            return Ok(list);
        }

        // GET api/<ResturantMenuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resturentMenu = _restaurantdbContext.Restaurantmenus.Find(id);
            if (resturentMenu == null)
            {
                return BadRequest("Invalied");
            }

            return Ok(resturentMenu);
        }

        // POST api/<ResturantMenuController>
        [HttpPost]
        public IActionResult Post([FromBody] RestaurantMenuModel resMenu)
        {

            var restaurent = _restaurantdbContext.Restaurants.Find(resMenu.RestaurantId);
            Restaurantmenu newRestaurant = new()
            {
                MealName = resMenu.MealName.ToTitleCase(),

                PriceInNis = resMenu.PriceInNis,

                PriceInUsd = resMenu.PriceInNis / 3.50,

                Quantity = resMenu.Quantity,

                RestaurantId = resMenu.RestaurantId,
            };
            newRestaurant.Restaurant = restaurent;

            _restaurantdbContext.Restaurantmenus.Add(newRestaurant);
            _restaurantdbContext.SaveChanges();

            return Ok();
        }

        // PUT api/<ResturantMenuController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RestaurantMenuModel restaurantMenuModel)
        {
            var restaurantM = _restaurantdbContext.Restaurantmenus
                                                .Find(id);
            if (restaurantM == null)
            {
                return BadRequest("Invalid Requset");
            }

            restaurantM.MealName = restaurantMenuModel.MealName.ToTitleCase();
            restaurantM.PriceInNis = restaurantMenuModel.PriceInNis;
            restaurantM.Quantity = restaurantMenuModel.Quantity;
            restaurantM.PriceInUsd = restaurantM.PriceInNis / 3.50;

            _restaurantdbContext.Restaurantmenus.Update(restaurantM);
            _restaurantdbContext.SaveChanges();
            return Ok(restaurantM);

        }

        // DELETE api/<ResturantMenuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resturent = _restaurantdbContext.Restaurantmenus.Find(id);
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
