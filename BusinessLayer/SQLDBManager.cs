using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SQLDBManager<T, K> : IDBManager<T, K> where K : IConvertible
    {
        private static SqlConnection connection;
        private static IDB<T, K> idbContext;

        //public IDBManager<T, K> SQLManager { get { return this; } }

        public SQLDBManager(string internalContext, string connectionString)
        {
            Load(internalContext, connectionString);
        }

        private static void Load(string internalContext, string connectionString)
        {
            if (ValidateConnectionString(connectionString))
            {
                switch (internalContext)
                {
                    case "customers":
                        idbContext = (IDB<T, K>)new CustomersContext(connection);
                        break;
                    case "products":
                        idbContext = (IDB<T, K>)new ProductsContext(connection);
                        break;
                    case "orders":
                        idbContext = (IDB<T, K>)new OrdersContext(connection);
                        break;
                    default:
                        throw new ArgumentException("Incorrect/Not implemented data type!");
                }
            }
        }

        private static bool ValidateConnectionString(string connectionString)
        {
            try
            {
                // Add Reference => System.Configuration
                // using System.Configuration for ConfigurationManager class

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Create(T item)
        {
            idbContext.Create(item);
        }

        public void Delete(K key)
        {
            idbContext.Delete(key);
        }

        public T Find(string index)
        {
            return idbContext.Find(index);
        }

        public T Read(K key)
        {
            return idbContext.Read(key);
        }

        public ICollection<T> ReadAll()
        {
            return idbContext.ReadAll();
        }

        public void Update(T item)
        {
            idbContext.Update(item);
        }

    }
}
