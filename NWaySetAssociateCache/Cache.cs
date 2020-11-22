using System;
using System.Collections.Generic;

namespace NWaySetAssociateCache
{
    public class Cache<T>
    {
        public List<DataBlock<T>> cacheBlocks;
        private IAlgorithm<T> _algorithm;
        private readonly int  _cacheSize;
        private readonly int _nSet;

        /// <summary>
        /// Contsructor for cache memory.
        /// </summary>
        /// <param name="cacheSize">Defines cache size</param>
        /// <param name="nSet">Defines ways' quantity</param>
        /// <param name="algorithm">Defines the cleaning/updating cache algorithm</param>
        public Cache(int cacheSize, int nSet, IAlgorithm<T> algorithm)
        {
            _algorithm = algorithm;
            _nSet = nSet;
            _cacheSize = cacheSize;
            cacheBlocks = new List<DataBlock<T>>();
        }

        /// <summary>
        /// Gets Block Index from 0 to N(ways number)
        /// </summary>
        /// <returns>Block Index</returns>
        public int GetDataBlockIndex(T key)
        {
            return Math.Abs(key.GetHashCode() % _nSet);
        }

        /// <summary>
        /// Puts key/value pair to cache memory.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Put(T key, T value)
        {
            var index = GetDataBlockIndex(key);
            cacheBlocks.Insert(index, new DataBlock<T>() {Key = key, Value = value });
            _algorithm.Add(key, value);
        }

        /// <summary>
        /// Gets the Value in cache by key.
        /// </summary>
        /// <typeparam name="T">Parametrs type</typeparam>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public T Get<T>(T key)
        {
            throw new NotImplementedException();
        }
    }
}
