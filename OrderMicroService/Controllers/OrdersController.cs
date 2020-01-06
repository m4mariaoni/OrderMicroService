using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroService.Data.Interface;
using OrderMicroService.Data.Model;

namespace OrderMicroServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

       

        // GET: api/GetAllOrders
        [HttpGet]
        [ActionName("GetAllOrders")]
        [Route("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                var category = _orderRepository.GetOrders();
                if (category == null)
                {
                    return new NotFoundObjectResult(category);
                }

                return new OkObjectResult(category);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);

            }

        }

        // POST: api/GetAllOrders
        [HttpPost]
        [ActionName("SaveOrders")]
        [Route("SaveOrders")]
        public IActionResult SaveOrders(Order order)
        {
            try
            {
                int orders = _orderRepository.InsertOrder(order);
                if (orders <= 0)
                {
                    return new NotFoundObjectResult(order);
                }

                return new OkObjectResult(orders);
            }
            catch (ArgumentException ex)
            {
                return Content(HttpStatusCode.BadRequest.ToString(), ex.Message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);

            }
        }
    }
}