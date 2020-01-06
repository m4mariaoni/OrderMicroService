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
    public class ProductMicroService : IProductMicroService
    {
        private readonly IConfiguration _configuration;

        public ProductMicroService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
  
        public Products Search(int productId)
        {

            var apiUrl = _configuration.GetExternalUrls().ProductMicroserviceUrl + "/api/Product/GetProductById?id=" + productId;
            var Client = new HttpClient();
            var response = Client.GetAsync(apiUrl).Result;
            var result = response.Content.ReadAsAsync<Products>().Result;
            Client.Dispose();
            return result;
        }


    }
}
