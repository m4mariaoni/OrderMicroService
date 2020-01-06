using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Model
{
    public class Order
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int productId { get; set; }
        public decimal amount { get; set; }
        public int customerId { get; set; }
    }
}
