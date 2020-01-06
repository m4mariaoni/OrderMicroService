using Dapper;
using Microsoft.Extensions.Configuration;
using OrderMicroService.Data.Interface;
using OrderMicroService.Data.Model;
using OrderMicroService.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Repo
{
    public class TrackerRepository : IOrderTrackerRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        private readonly IExternalConnectionProvider _otherConnectionStringProvider;

        public TrackerRepository(IDatabaseConnectionProvider databaseConnectionProvider
            , IExternalConnectionProvider otherConnectionStringProvider
            )
        {
            _databaseConnectionProvider = databaseConnectionProvider;
            _otherConnectionStringProvider = otherConnectionStringProvider;
        }
        public IEnumerable<OrderTracker> GetOrderById(int OrderId)
        {
            var orders = new List<OrderTracker>();
            using (var connection = _databaseConnectionProvider.GetDbConnection())
            {
                orders = connection.Query<OrderTracker>(@"SELECT * from orderstatus WHERE orderid = @orderid", new { OrderId}).ToList();


            }
            return orders;
        }

        public List<OrderTracker> GetTrackOrders()
        {
            throw new NotImplementedException();
        }

        public int InsertOrder(OrderTracker OrderTracker)
        {
            using (var connection = _databaseConnectionProvider.GetDbConnection())
            {
              
                    var insertQuery = @"INSERT INTO orderstatus(orderid,status) VALUES(@OrderId,@OrderStatus)";
                    int id = connection.Execute(insertQuery, OrderTracker);
                    if (id <= 0)
                    {
                        throw new ArgumentException("An error has occured");
                    }
                    return id;

            }
        }
    }
}
