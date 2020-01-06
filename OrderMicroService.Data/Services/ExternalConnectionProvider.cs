using Microsoft.Extensions.Configuration;
using OrderMicroService.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Services
{
    public class ExternalConnectionProvider : IExternalConnectionProvider
    {
        private readonly IConfiguration _configuration;
        public ExternalConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    

        public string GetProductMicroserviceUrl()
        {
            //var bb = _configuration.GetSection("ProductMicroServiceUrl").GetChildren().FirstOrDefault();
            return _configuration.GetSection("ExternalUrl:ProductMicroserviceUrl").Value;
        }

        public string GetCustomerMicroserviceUrl()
        {
            return _configuration.GetSection("ExternalUrl:CustomerMicroserviceUrl").Value;

        }


    }
}
