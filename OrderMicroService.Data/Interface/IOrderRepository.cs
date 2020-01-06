using OrderMicroService.Data.Model;
using OrderMicroService.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Interface
{
    public interface IOrderRepository
    {
        List<OrdersViewModel> GetOrders();
        Order GetOrderById(int OrderId);
        int InsertOrder(Order Order);
        int UpdateProduct(Order Order);
    }
}
