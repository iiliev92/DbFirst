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
        private static FactoryManager<Customer, int> customerManager;
        private static FactoryManager<Product, string> productManager;
        private static FactoryManager<Order, int> orderManager;

        public static void Run(string internalContext, string dbManager, string connectionString, string command, params object[] arguments)
        {
            switch (internalContext)
            {
                case "customers":

                    if (customerManager == null || customerManager.connectionString != connectionString)
                    {
                        customerManager = new FactoryManager<Customer, int>(dbManager, internalContext, connectionString);
                    }

                    switch (command)
                    {
                        case "create":

                            Customer customer = CustomerMapper.GetCustomer(arguments[0].ToString(), arguments[1].ToString(), arguments[2].ToString());
                            
                            if (customer != null)
                            {
                                customerManager.Create(customer);
                            }

                             break;

                        case "read":
                            ;
                            break;

                        case "update":
                            ;
                            break;

                        case "delete":

                            Customer foundCustomer = customerManager.Find(arguments[0].ToString());

                            if (foundCustomer != null)
                            {
                                customerManager.Delete(Convert.ToInt32(foundCustomer.id));
                            }
                            else
                            {
                                throw new ArgumentNullException("There is no customer with that name!", new NullReferenceException());
                            }
                            
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
