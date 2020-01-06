using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Model
{
    public class Deliveries
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
    }
}
