using Npgsql;
using OrderMicroService.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Services
{
    public class DefaultDatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        public DefaultDatabaseConnectionProvider(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection GetDbConnection()
        {
            return new NpgsqlConnection(_connectionStringProvider.GetConnectionStringName());
        }

    }
}
