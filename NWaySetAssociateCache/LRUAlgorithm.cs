using System;
using System.Collections.Generic;
using System.Text;

namespace NWaySetAssociateCache
{
    public class LRUAlgorithm<T> : IAlgorithm<T>
    {
        private Dictionary<int, Entry> hashMap;
        private int _capacity;
        private readonly Cache<T> _cache;
        public LRUAlgorithm(int cacheSize)
        {
            _capacity = cacheSize;
        }
        public void Add(T key, T value)
        {
            throw new NotImplementedException();
        }

        public void Remove(T key)
        {
            throw new NotImplementedException();
        }

        public void Update(T key)
        {
            throw new NotImplementedException();
        }
        public T Get(T key)
        {
            throw new NotImplementedException();
        }
    }

}
