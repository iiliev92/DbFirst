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

            command.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void Delete(int key)
        {
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("delete from Customers where id = @id", sqlConnection);

            command.Parameters.AddWithValue("@id", key);

            command.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public Customer Find(string index)
        {
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("select * from Customers where name = @name", sqlConnection);

            command.Parameters.AddWithValue("@name", index);

            Customer customer = null;
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    customer = new Customer();
                    customer.id = Convert.ToInt32(reader["id"]);
                    customer.name = reader["name"].ToString();
                    customer.address = reader["address"].ToString();
                    customer.email = reader["email"].ToString();
                }
            }

            sqlConnection.Close();

            return customer;
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
