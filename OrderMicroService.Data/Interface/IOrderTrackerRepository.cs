using OrderMicroService.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Interface
{
    public interface IOrderTrackerRepository
    {

        List<OrderTracker> GetTrackOrders();
        int InsertOrder(OrderTracker Order);
        IEnumerable<OrderTracker> GetOrderById(int OrderId);
    }
}
