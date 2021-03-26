using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;
using ViewLayer;

namespace PresentationLayer
{
    class Program
    {
        static string connectionString;

        static void Main(string[] args)
        {
            
            // User should enter the connection string
            connectionString = "DatabaseFirst11jv1Entities";

            // To Do: Create Menu and Validate user input!

            int choice = -1;

            do
            {
                try
                {
                    Console.WriteLine("1) Customers");
                    Console.WriteLine("2) Products");
                    Console.WriteLine("3) Orders");
                    Console.WriteLine("4) Exit");

                    Console.Write("Your choice: ");
                    choice = int.Parse(Console.ReadLine());

                    if (choice < 1 || choice > 3)
                    {
                        break;
                    }

                    Console.Clear();

                    int innerChoice = -1;

                    switch (choice)
                    {
                        case 1:
                            ShowMenu("Customers", out innerChoice);

                            switch (innerChoice)
                            {
                                case 1:
                                    CreateCustomer();
                                    break;
                                case 2:
                                    ReadCustomer();
                                    break;
                                case 3:
                                    ReadAllCustomers();
                                    break;
                                case 4:
                                    UpdateCustomer();
                                    break;
                                case 5:
                                    DeleteCustomer();
                                    break;
                                case 6:
                                    FindCustomer();
                                    break;
                                default:
                                    break;
                            }

                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine();
                    Console.WriteLine(ane.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey();
                Console.Clear();

            } while (choice != 4);
        }

        #region Customers Methods

        private static void ShowMenu(string header, out int innerChoice)
        {
            Console.WriteLine("### {0} Menu ###", header);
            Console.WriteLine("1) Create");
            Console.WriteLine("2) Read");
            Console.WriteLine("3) Read All");
            Console.WriteLine("4) Update");
            Console.WriteLine("5) Delete");
            Console.WriteLine("6) Find");

            do
            {
                Console.Write("Your choice: ");
                innerChoice = int.Parse(Console.ReadLine());
                Console.WriteLine();
            } while (innerChoice < 1 || innerChoice > 6 );
        }

        private static void CreateCustomer()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            DBManager.Run("customers", "sql", connectionString, "create", name, address, email);

            Console.WriteLine();
            Console.WriteLine("Customer added successfully! Press any key to continue ...");
        }

        private static void ReadCustomer()
        {
            int id = EnterID();
            DBManager.Run("customers", "sql", connectionString, "read", id);
        }

        private static void ReadAllCustomers()
        {
            DBManager.Run("customers", "sql", connectionString, "read all");
        }

        private static void UpdateCustomer()
        {
            DBManager.Run("customers", "sql", connectionString, "read all");

            Console.WriteLine("Enter [1-n] to choose the customer you want to edit");
            int id = EnterID();
            
            DBManager.Run("customers", "sql", connectionString, "read", id);

            Console.Write("New Name: ");
            string name = Console.ReadLine();

            Console.Write("New Address: ");
            string address = Console.ReadLine();

            Console.Write("New Email: ");
            string email = Console.ReadLine();

            DBManager.Run("customers", "sql", connectionString, "update", name, address, email, id);

            Console.WriteLine();
            Console.WriteLine("Customer updated successfully! Press any key to continue ...");
        }

        private static void DeleteCustomer()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            DBManager.Run("customers", "sql", connectionString, "delete", name);

            Console.WriteLine();
            Console.WriteLine("Customer deleted successfully! Press any key to continue ...");
        }

        private static void FindCustomer()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            DBManager.Run("customers", "sql", connectionString, "find", name);
        }

        #endregion

        #region Products


        #endregion

        #region Orders


        #endregion

        #region Helper Methods

        private static int EnterID()
        {
            bool validType = false;
            int id;

            do
            {
                Console.Write("ID = ");
                
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    validType = true;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter valid data type [int]!");
                }
            } while (!validType);

            return id;
        }

        #endregion

    }
}
