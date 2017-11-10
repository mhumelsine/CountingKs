using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.Stores
{
    public interface IAddable<T>
    {
        void Add(T item);
    }
}
