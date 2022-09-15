using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject1.Models;
using RestaurantProject1.ModelViews;
using RestaurantProject1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerorderController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public CustomerorderController(restaurantdbContext r)
        {
            _restaurantdbContext = r;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var list = _restaurantdbContext.Customerorders.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Order(int resMenuid, int orderQuantity, OrderModel orderModel)
        {

            var availablty = Helper.isAvailable(resMenuid, _restaurantdbContext);
            if (availablty)
            {
                Customerorder order = new()
                {
                    CustmerId = orderModel.CustmerId,
                    MealId = orderModel.MealId
                };
                order.CustmerOrderQuntity = orderQuantity;
                var resturentModel = _restaurantdbContext.Restaurantmenus.Find(order.MealId);
                resturentModel.Quantity = resturentModel.Quantity - orderQuantity;
                if (resturentModel.Quantity < 0)
                {
                    return BadRequest("Invalid Requset");
                }
                _restaurantdbContext.Customerorders.Add(order);
                _restaurantdbContext.Restaurantmenus.Update(resturentModel);
                _restaurantdbContext.SaveChanges();
                return Ok(order);
            }

            return BadRequest("Invalid Requset");

        }

        [HttpPut]
        public IActionResult UpdateOrder(int orderId, int UpdatedQuantity)
        {
            var custmerOrder = _restaurantdbContext.Customerorders.Find(orderId);
            var preQuantity = custmerOrder.CustmerOrderQuntity;
            // Restarunt Menu changes
            var resMenu = _restaurantdbContext.Restaurantmenus.Find(custmerOrder.MealId);
            var availablty = Helper.isAvailable(custmerOrder.MealId, _restaurantdbContext);
            if (custmerOrder != null)
            {
                if (availablty)
                {
                    if (UpdatedQuantity > preQuantity)
                    {
                        var increase = UpdatedQuantity - preQuantity;
                        custmerOrder.CustmerOrderQuntity = UpdatedQuantity;
                        resMenu.Quantity = resMenu.Quantity - increase;
                        if (resMenu.Quantity < 0)
                        {
                            return BadRequest("Invalied Requaset");
                        }
                        _restaurantdbContext.Restaurantmenus.Update(resMenu);
                        _restaurantdbContext.Customerorders.Update(custmerOrder);
                        _restaurantdbContext.SaveChanges();
                        return Ok();
                    }
                    else if (UpdatedQuantity < preQuantity)
                    {
                        var decrease = preQuantity - UpdatedQuantity;
                        custmerOrder.CustmerOrderQuntity = UpdatedQuantity;
                        resMenu.Quantity = resMenu.Quantity + decrease;
                        _restaurantdbContext.Restaurantmenus.Update(resMenu);
                        _restaurantdbContext.Customerorders.Update(custmerOrder);
                        _restaurantdbContext.SaveChanges();
                        return Ok();
                    }
                }

            }


            return BadRequest("Invalid Requset");
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int orderId)
        {
            var order = _restaurantdbContext.Customerorders.Find(orderId);
            if (order != null)
            {
                _restaurantdbContext.Customerorders.Remove(order);
                _restaurantdbContext.SaveChanges();
                return Ok("Deleted Succsefly");
            }
            return BadRequest("Invlaid Requset");

        }

       


    }

}
