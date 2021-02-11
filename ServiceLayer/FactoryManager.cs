using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace ServiceLayer
{
    internal class FactoryManager<T, K> where K : IConvertible
    {
        private static IDBManager<T, K> idbManager;

        public FactoryManager(string dbManager, string internalContext, string connectionString)
        {
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

        internal void Create(T item)
        {
            idbManager.Create(item);
        }

    }
}
