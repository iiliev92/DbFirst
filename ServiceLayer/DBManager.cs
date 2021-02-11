using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class DBManager
    {

        public static void Run(string internalContext, string dbManager, string connectionString, string command, params object[] arguments)
        {
            switch (internalContext)
            {
                case "customers":

                    switch (command)
                    {
                        case "create":

                            Customer customer = CustomerMapper.GetCustomer(arguments[0].ToString(), arguments[1].ToString(), arguments[2].ToString());
                            
                            if (customer != null)
                            {
                                new FactoryManager<Customer, int>(dbManager, internalContext, connectionString).Create(customer);
                            }
                             break;
                        case "read":
                            ;
                            break;
                        case "update":
                            ;
                            break;
                        case "delete":
                            ;
                            break;
                        default:
                            break;
                    }
                    break;

                case "products":
                    ;
                    break;

                case "orders":
                    ;
                    break;
                default:
                    break;
            }
        }

    }
}
