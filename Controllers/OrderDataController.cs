using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Order_Manager.Models;
using Order_Manager.Models.Domain;
using Order_Manager.Models.ViewModels;
using Order_Manager.Services;
using static Order_Manager.Services.OrderServices;

namespace Order_Manager.Controllers
{
    [Route("api/[controller]")]
    public class OrderDataController: Controller
    {
        OrderContext _cxt;
        public OrderDataController(OrderContext cxt){
            _cxt = cxt;
        }

        [HttpPost("Order")]
        public IActionResult Order([FromBody] CartOrdersViewModel model){
            try{
            if(ModelState.IsValid){
                Cart cart = new Cart();
                cart.CustomerName = model.customerName;
                cart.Email = model.email;
                cart.PhoneNumber = model.phoneNumber;
                cart.IsDelivered = false;
                cart.OfficeId = new OrderServices(_cxt).GetClosestOffice(model.longitude, model.latitude).OfficeId;
                _cxt.Carts.Add(cart);
                foreach(var c in model.orders)
                {
                    Order order = new Order{
                        ProductId = c.productId,
                        Price = c.price,
                        Quantity = c.quantity,
                        CartId = cart.CartId
                    };
                    _cxt.Orders.Add(order);
                }
                _cxt.SaveChanges();
            }
            return Json("Order Made Successfully");
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("locate")]
        public IActionResult locate(){
            OrderServices orderservice = new OrderServices(_cxt);
            // 9.081999<br>Longitude: 8.675277
            Distances dist = orderservice.GetClosestOffice(8.675277, 9.081999);
            return Json(dist);
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts(){
            var products = new OrderServices(_cxt).GetProducts();
            return Json(products);
        }

        [HttpGet("GetCarts")]
        public IActionResult GetCarts()
        {
            List<CartViewModel> carts = new OrderServices(_cxt).GetAllCarts();
            return Json(carts);
        }
    }
}