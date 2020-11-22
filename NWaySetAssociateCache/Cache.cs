using System;
using System.Collections.Generic;
using System.Linq;

namespace NWaySetAssociateCache
{
    public class Cache<T>
    {
        public Dictionary<T, T>[] cacheBlocks;
        private IAlgorithm<T> _algorithm;
        private readonly int _cacheSize;
        private int _nSet;

        private int NSet
        {
            get
            {
                return _nSet;
            }
            set
            {
                _nSet = (value <= _cacheSize) ? value : throw new CacheException("N ways number exceeds cache size.");
            }
        }

        /// <summary>
        /// Contsructor for cache memory.
        /// </summary>
        /// <param name="cacheSize">Defines cache size</param>
        /// <param name="nSet">Defines ways' quantity</param>
        /// <param name="algorithm">Defines the cleaning/updating cache algorithm</param>
        public Cache(int cacheSize, int nSet, IAlgorithm<T> algorithm)
        {
            _algorithm = algorithm;
            _cacheSize = cacheSize;
            NSet = nSet;
            cacheBlocks = new Dictionary<T, T>[nSet - 1];
        }

        /// <summary>
        /// Gets Block Index from 0 to N-1(ways number)
        /// </summary>
        /// <returns>Block Index</returns>
        public int GetDataBlockIndex(T key)
        {
            return Math.Abs(key.GetHashCode() % NSet);
        }

        /// <summary>
        /// Puts key/value pair to cache memory.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Put(T key, T value)
        {
            var index = GetDataBlockIndex(key);
            if(cacheBlocks[index] == null)
            {
                cacheBlocks[index] = new Dictionary<T, T> { };
            }
            cacheBlocks[index].Add(key, value);
            _algorithm.Add(key, value);
        }

        /// <summary>
        /// Gets the Value in cache by key.
        /// </summary>
        /// <typeparam name="T">Parametrs type</typeparam>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public T Get(T key)
        {
            int index = GetDataBlockIndex(key);
            T value;
            if(!cacheBlocks[index].TryGetValue(key, out value))
            {
                throw new CacheException("Cache error: Cannot get value by key.");
            }
            return value;
        }
    }
}
