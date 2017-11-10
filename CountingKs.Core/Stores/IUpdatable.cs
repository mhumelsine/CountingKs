using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.Stores
{
    public interface IUpdatable<T>
    {
        void Update(T item);
    }
}
