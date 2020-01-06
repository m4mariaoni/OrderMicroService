using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Interface
{
    public interface IDatabaseConnectionProvider
    {
        IDbConnection GetDbConnection();
     
       
    }
}
