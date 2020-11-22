using System;
using System.Collections.Generic;
using System.Text;

namespace NWaySetAssociateCache
{
    public interface IAlgorithm<T>
    {
        public void Add(T key, T value);
        public void Update(T key);
    }
}
