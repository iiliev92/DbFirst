using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BusinessLayer
{
    internal class OrdersContext : IDB<Order, int>
    {
        //MySQL.Data.MySQLClient => for MySQL
        private SqlConnection connection;

        public OrdersContext(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Create(Order item)
        {

            connection.Open();

            // Must implement:

            SqlCommand command = new SqlCommand("insert into Orders(???) values (@???)", connection);


            
            int result = command.ExecuteNonQuery();

            //Console.WriteLine(result);

            connection.Close();

        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Order Find(string index)
        {
            throw new NotImplementedException();
        }

        public Order Read(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
