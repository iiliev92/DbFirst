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
        private SqlConnection connection;

        public CustomersContext(SqlConnection sqlConnection)
        {
            this.connection = sqlConnection;
        }

        public void Create(Customer item)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("insert into Customers(name, address, email) values (@name, @address, @email)", connection);

            command.Parameters.AddWithValue("@name", item.name);
            command.Parameters.AddWithValue("@address", item.address);
            command.Parameters.AddWithValue("@email", item.email);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public Customer Read(int key)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from Customers where id = @id", connection);

            command.Parameters.AddWithValue("@id", key);

            Customer customer = null;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    connection.Close();
                    throw new ArgumentNullException("There is no customer with that id!", new NullReferenceException());
                }

                customer = new Customer();
                customer.id = Convert.ToInt32(reader["id"]);
                customer.name = reader["name"].ToString();
                customer.address = reader["address"].ToString();
                customer.email = reader["email"].ToString();
            }

            connection.Close();

            return customer;
        }

        public ICollection<Customer> ReadAll()
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from Customers", connection);

            ICollection<Customer> customers = new List<Customer>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.id = Convert.ToInt32(reader["id"]);
                    customer.name = reader["name"].ToString();
                    customer.address = reader["address"].ToString();
                    customer.email = reader["email"].ToString();

                    customers.Add(customer);
                }
            }

            connection.Close();

            return customers;
        }

        public void Update(Customer item)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("update Customers set name = @name, address = @address, " +
                "email = @email where id = @id", connection);

            command.Parameters.AddWithValue("@name", item.name);
            command.Parameters.AddWithValue("@address", item.address);
            command.Parameters.AddWithValue("@email", item.email);
            command.Parameters.AddWithValue("@id", item.id);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(int key)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("delete from Customers where id = @id", connection);

            command.Parameters.AddWithValue("@id", key);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public Customer Find(string index)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from Customers where name = @name", connection);

            command.Parameters.AddWithValue("@name", index);

            Customer customer = null;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    connection.Close();
                    throw new ArgumentNullException("There is no customer with that name!", new NullReferenceException());
                }

                customer = new Customer();
                customer.id = Convert.ToInt32(reader["id"]);
                customer.name = reader["name"].ToString();
                customer.address = reader["address"].ToString();
                customer.email = reader["email"].ToString();
            }

            connection.Close();

            return customer;
        }

    }
}
