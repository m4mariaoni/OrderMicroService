using Dapper;
using OrderMicroService.Data.Interface;
using OrderMicroService.Data.Model;
using OrderMicroService.Data.Services;
using OrderMicroService.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Repo
{
    public class OrderRepository :IOrderRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        private readonly IExternalConnectionProvider _otherConnectionStringProvider;
        private readonly IProductMicroService _productMicroService;
        private readonly ICustomerMicroService _customerMicroService;

        public OrderRepository(IDatabaseConnectionProvider databaseConnectionProvider 
            ,IExternalConnectionProvider otherConnectionStringProvider,
            IProductMicroService productMicroService,
            ICustomerMicroService customerMicroService
            )
        {
            _databaseConnectionProvider = databaseConnectionProvider;
           _otherConnectionStringProvider = otherConnectionStringProvider;
            _productMicroService = productMicroService;
           _customerMicroService = customerMicroService;
        }

        public Order GetOrderById(int OrderId)
        {
            throw new NotImplementedException();
        }

        public List<OrdersViewModel> GetOrders()
        {      
           
            List<OrdersViewModel> allOrders = new List<OrdersViewModel>();
            using (var connection = _databaseConnectionProvider.GetDbConnection())
            {
                var orders = connection.Query<Order>("Select * from orders");
                foreach (var item in orders)
                {
                    OrdersViewModel model = new OrdersViewModel();
                    var product = _productMicroService.Search(item.productId);
                    var customer = _customerMicroService.Search(item.customerId);
                    model.Id = item.id;
                    model.Amount = item.amount;
                    model.ProductId = item.productId;
                    model.ProductName = product.Name;
                    model.Quantity = item.quantity;
                    model.CustomerId = item.customerId;
                    model.CustomerName = customer.Fullname;

                    allOrders.Add(model);
                }
                

              
            }

            return allOrders;
        }

        public int InsertOrder(Order order)
        {
            using (var connection = _databaseConnectionProvider.GetDbConnection())
            {
                var insertQuery = @"INSERT INTO orders(quantity,productid,amount,customerid) VALUES(@quantity,@productid,@amount,@customerid)";

                int id = connection.Execute(insertQuery, order);
                if (id <= 0)
                {
                    throw new ArgumentException("An error has occured");
                }
                return id;

            }
        }

        public int UpdateProduct(Order Order)
        {
            throw new NotImplementedException();
        }
    }
}
