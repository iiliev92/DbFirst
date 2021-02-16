using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using ViewLayer;

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

                            Customer customerToCreate = CustomerMapper.GetCustomer(arguments[0].ToString(), arguments[1].ToString(), arguments[2].ToString());
                            
                            customerManager.Create(customerToCreate);
                            
                            break;

                        case "read":

                            int id = Convert.ToInt32(arguments[0].ToString());
                            Customer foundCustomer = customerManager.Read(id);

                            // Service Layer calls ViewLayer, not Presentation Layer 
                            // because of circular dependency!
                            CustomerView.ShowCustomer(foundCustomer.id, foundCustomer.name, foundCustomer.address, foundCustomer.email);

                            break;

                        case "read all":

                            ShowAllCustomers();

                            break;

                        case "update":

                            Customer customerToUpdate = new Customer();

                            customerToUpdate.name = arguments[0].ToString();
                            customerToUpdate.address = arguments[1].ToString();
                            customerToUpdate.email = arguments[2].ToString(); 
                            customerToUpdate.id = Convert.ToInt32(arguments[3]);
                            
                            customerManager.Update(customerToUpdate);
                            
                            break;

                        case "delete":

                            Customer customerToDelete = customerManager.Find(arguments[0].ToString());

                            //if (customerToDelete != null) => I already check for null and throw exception in CustomersContext
                            customerManager.Delete(Convert.ToInt32(customerToDelete.id));
                            
                            break;

                        case "find":
                            Customer foundCustomerByName = customerManager.Find(arguments[0].ToString());

                            CustomerView.ShowCustomer(foundCustomerByName.id, foundCustomerByName.name, foundCustomerByName.address, foundCustomerByName.email);

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

        private static void ShowAllCustomers()
        {
            ICollection<Customer> customers = customerManager.ReadAll();
            int customerCounter = 1;

            foreach (var customer in customers)
            {
                CustomerView.SetHeader(string.Format("#{0} Info:", customerCounter));
                CustomerView.ShowCustomer(customer.id, customer.name, customer.address, customer.email);
                CustomerView.SetFooter("######################" + Environment.NewLine);

                customerCounter++;
            }

            
        }
    }
}
