﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    interface IDB<T, K> where K : IConvertible
    {
        void Create(T item);

        T Read(K key);

        ICollection<T> ReadAll();

        void Update(T item);

        void Delete(K key);

        T Find(string index);

    }
}
