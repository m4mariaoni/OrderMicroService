using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Model
{
    public class Enum
    {
        public enum OrderStatus
       {
            Packed = 1,
            ReadytoShip  = 2,
            Delivered = 3
        }
    }
}
