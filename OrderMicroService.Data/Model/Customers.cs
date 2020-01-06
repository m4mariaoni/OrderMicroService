using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Data.Model
{
    public class Customers
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }

        public string Fullname
        {
            get { return Lastname + " "+ Firstname; }
        }
    }
}
