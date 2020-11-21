using System;
using System.Collections.Generic;

namespace NWaySetAssociateCache
{
    public class Cache<T>
    {
        private IAlgorithm _algorithm;
        private readonly int  _cacheSize;
        private readonly int _nSet;

        /// <summary>
        /// Contsructor for cache memory.
        /// </summary>
        /// <param name="cacheSize">Defines cache size</param>
        /// <param name="nSet">Defines ways' quantity</param>
        /// <param name="algorithm">Defines the cleaning/updating cache algorithm</param>
        public Cache(int cacheSize, int nSet, IAlgorithm algorithm)
        {
            _algorithm = algorithm;
            _nSet = nSet;
            _cacheSize = cacheSize;
        }

        /// <summary>
        /// Puts key/value pair to cache memory.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Put(T key, T value)
        {
            throw new NotImplementedException();
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
