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
    public class OrderTrackerController : ControllerBase
    {
        private readonly IOrderTrackerRepository _orderTrackerRepository;
        public OrderTrackerController(IOrderTrackerRepository orderTrackerRepository)
        {
            _orderTrackerRepository = orderTrackerRepository;
        }
        // POST: api/GetAllOrders
        [HttpPost]
        [ActionName("SaveTracker")]
        [Route("SaveTracker")]
        public IActionResult SaveTracker(OrderTracker order)
        {
            try
            {
                int orders = _orderTrackerRepository.InsertOrder(order);
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