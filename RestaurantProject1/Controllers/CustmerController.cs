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
    public class CustmerController : ControllerBase
    {


        private restaurantdbContext _restaurantdbContext;

        public CustmerController(restaurantdbContext r)
        {

            _restaurantdbContext = r;
        }

        // GET: api/<CustmerController>
        [HttpGet]
        public IActionResult Get()
        {

            var Custmerlist = _restaurantdbContext.Customers.ToList();


            return Ok(Custmerlist);
        }

        // GET api/<CustmerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var custmer = _restaurantdbContext.Customers.Find(id);
            if (custmer == null)
            {
                return BadRequest("Invalid Requset");
            }


            return Ok(custmer);
        }

        // POST api/<CustmerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustmerModel custmerModel)
        {
            Customer custmer = new()
            {
                FirstName = custmerModel.FirstName.ToTitleCase(),
                LastName = custmerModel.LastName.ToTitleCase()
            };

            _restaurantdbContext.Customers.Add(custmer);
            _restaurantdbContext.SaveChanges();

            return Ok(custmer);
        }

        // PUT api/<CustmerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustmerModel custmerModel)
        {
            var custmer = _restaurantdbContext.Customers
                                                .Find(id);
            if (custmer == null)
            {
                return BadRequest("Invalid Requset");
            }

            custmer.FirstName = custmerModel.FirstName.ToTitleCase();
            custmer.LastName = custmerModel.LastName.ToTitleCase();
         

            _restaurantdbContext.Customers.Update(custmer);
            _restaurantdbContext.SaveChanges();
            return Ok(custmer);
        }

        // DELETE api/<CustmerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var customer = _restaurantdbContext.Customers.Find(id);
            if (customer == null)
            {
                return BadRequest("Invalied");
            }

            customer.Archived = true;
            _restaurantdbContext.SaveChanges();
            return Ok(customer);
        }

    }
}
