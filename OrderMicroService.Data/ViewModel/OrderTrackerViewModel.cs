using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMicroService.Data.Model.Enum;

namespace OrderMicroService.Data.ViewModel
{
    public class OrderTrackerViewModel
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        
    }
}
