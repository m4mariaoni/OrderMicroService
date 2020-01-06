using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderMicroService.Data.Model.Enum;

namespace OrderMicroService.Data.Model
{
    public class OrderTracker
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        public  OrderStatus  orderStatus{ get;set; }
    }
}
