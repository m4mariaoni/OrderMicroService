using Microsoft.Extensions.Configuration;
using OrderMicroService.Data.Interface;
using OrderMicroService.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Services
{
    public class CustomerMicroService : ICustomerMicroService
    {
        private readonly IConfiguration _configuration;

        public CustomerMicroService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public Customers Search(int customerid)
        {
            var apiUrl = _configuration.GetExternalUrls().CustomerMicroserviceUrl + "/api/Customers/" + customerid;
            var Client = new HttpClient();
            var response = Client.GetAsync(apiUrl).Result;
            var result = response.Content.ReadAsAsync<Customers>().Result;
            Client.Dispose();
            return result;
        }
    }
}
