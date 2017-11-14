using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.Stores
{
    public interface IDeletable<T>
    {
        void Delete(T item);
    }
}
