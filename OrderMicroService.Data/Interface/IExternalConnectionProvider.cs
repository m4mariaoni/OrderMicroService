using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Interface
{
    public interface IExternalConnectionProvider
    {
        string GetProductMicroserviceUrl();

        string GetCustomerMicroserviceUrl();
   
    }
}
