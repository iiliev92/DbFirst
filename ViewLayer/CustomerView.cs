using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLayer
{
    public static class CustomerView
    {
        public static void ShowCustomer(int id, string name, string address, string email)
        {
            Console.WriteLine("ID: {0}", id);
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Address: {0}", address);
            Console.WriteLine("Email: {0}", email);
            Console.WriteLine();
        }

        public static void SetHeader(string heading)
        {
            Console.WriteLine(heading);
        }

        public static void SetFooter(string heading)
        {
            Console.WriteLine(heading);
        }
    }
}
