using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace ServiceLayer
{
    internal class FactoryManager<T, K> : IDBManager<T, K> where K : IConvertible
    {
        private static IDBManager<T, K> idbManager;

        internal string connectionString;

        public FactoryManager(string dbManager, string internalContext, string connectionString)
        {
            this.connectionString = connectionString;
            Load(dbManager, internalContext, connectionString);
        }

        internal static void Load(string dbManager, string internalContext, string connectionString)
        {
            switch (dbManager)
            {
                case "sql":
                    idbManager = new SQLDBManager<T, K>(internalContext, connectionString);
                    break;
                case "ef":
                    ;
                    break;
                case "xml":
                    ;
                    break;
                default:
                    break;
            }

            
        }

        public void Create(T item)
        {
            idbManager.Create(item);
        }

        public T Read(K key)
        {
            return idbManager.Read(key);
        }

        public ICollection<T> ReadAll()
        {
            return idbManager.ReadAll();
        }

        public void Update(T item)
        {
            idbManager.Update(item);
        }

        public void Delete(K key)
        {
            idbManager.Delete(key);
        }

        public T Find(string index)
        {
            return idbManager.Find(index);
        }
    }
}
