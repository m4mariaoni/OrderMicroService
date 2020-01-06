using Microsoft.Extensions.Configuration;
using OrderMicroService.Data.Interface;
using OrderMicroService.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Services
{
    public class DefaultConnectionStringProvider : IConnectionStringProvider
    {

        private readonly IConfiguration _configuration;
        public DefaultConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionStringName()
        {           
           
            return _configuration.GetConnectionString("OrderDB");
        }


       
    }
}
