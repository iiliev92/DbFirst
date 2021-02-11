using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class CustomersContext : IDB<Customer, int>
    {
        //MySQL.Data.MySQLClient => for MySQL
        private SqlConnection sqlConnection;


        public CustomersContext(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Create(Customer item)
        {
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("insert into Customers(name, address, email) values (@name, @address, @email)", sqlConnection);

            command.Parameters.AddWithValue("@name", item.name);
            command.Parameters.AddWithValue("@address", item.address);
            command.Parameters.AddWithValue("@email", item.email);

            int result = command.ExecuteNonQuery();

            //Console.WriteLine(result);

            sqlConnection.Close();

        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Customer Read(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
