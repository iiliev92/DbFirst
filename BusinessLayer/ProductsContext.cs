using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BusinessLayer
{
    internal class ProductsContext : IDB<Product, string>
    {
        //MySQL.Data.MySQLClient => for MySQL
        private SqlConnection connection;

        public ProductsContext(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Create(Product item)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("insert into Products(barcode, name, price, quantity) values (@barcode, @name, @price, @quantity)", connection);

            command.Parameters.AddWithValue("@barcode", item.barcode);
            command.Parameters.AddWithValue("@name", item.name);
            command.Parameters.AddWithValue("@price", item.price);
            command.Parameters.AddWithValue("@quantity", item.quantity);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public Product Read(string key)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from Products where barcode = @barcode", connection);

            command.Parameters.AddWithValue("@barcode", key);

            Product product = null;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    connection.Close();
                    throw new ArgumentNullException("There is no product with that id!", new NullReferenceException());
                }

                product = new Product();
                product.barcode = reader["barcode"].ToString();
                product.name = reader["name"].ToString();
                product.quantity = (int)reader["quantity"];
                product.price = (decimal)reader["price"];
            }

            connection.Close();

            return product;
        }

        public ICollection<Product> ReadAll()
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from Products", connection);

            ICollection<Product> products = new List<Product>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.barcode = reader["barcode"].ToString();
                    product.name = reader["name"].ToString();
                    product.quantity = (int)reader["quantity"];
                    product.price = (decimal)reader["price"];

                    products.Add(product);
                }
            }

            connection.Close();

            return products;
        }

        public void Update(Product item)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("update Products set name = @name, " +
                "quantity = @quantity, price = @price where barcode = @barcode", connection);

            command.Parameters.AddWithValue("@name", item.name);
            command.Parameters.AddWithValue("@quantity", item.quantity);
            command.Parameters.AddWithValue("@price", item.price);
            command.Parameters.AddWithValue("@barcode", item.barcode);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(string key)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("delete from Products where barcode = @barcode", connection);

            command.Parameters.AddWithValue("@barcode", key);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public Product Find(string index)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select * from Products where name = @name", connection);

            command.Parameters.AddWithValue("@name", index);

            Product product = null;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    connection.Close();
                    throw new ArgumentNullException("There is no product with that name!", new NullReferenceException());
                }

                product = new Product();
                product.barcode = reader["barcode"].ToString();
                product.name = reader["name"].ToString();
                product.quantity = (int)reader["quantity"];
                product.price = (decimal)reader["price"];
            }

            connection.Close();

            return product;
        }

    }
}
