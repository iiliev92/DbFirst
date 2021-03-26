using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class CustomerMapper
    {
        internal static Customer GetCustomer(string name, string address, string email)
        {
            Customer customer = new Customer();
            customer.name = name;
            customer.address = address;
            customer.email = email;

            return customer;
        }
    }
}
