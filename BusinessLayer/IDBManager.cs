using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IDBManager<T, K> where K : IConvertible
    {
        void Create(T item);
        
    }
}
