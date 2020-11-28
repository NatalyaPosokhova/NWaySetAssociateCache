using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NWaySetAssociateCache
{
    public class LRUAlgorithm<T> : IAlgorithm<T>
    {
        private LinkedList<KeyValuePair<T, T>> lruListCache;
        private int _capacity;
        /// <summary>
        /// Constructor for LRU Algorithm of clearing cache.
        /// </summary>
        /// <param name="cacheSize"></param>
        public LRUAlgorithm(int cacheSize)
        {
            _capacity = cacheSize;
            lruListCache = new LinkedList<KeyValuePair<T, T>>();
        }
        /// <summary>
        /// Adds key/value pair to LRU cache list.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(T key, T value)
        {
            lruListCache.AddFirst(new KeyValuePair<T, T>(key, value));
        }
        /// <summary>
        /// Removes key/value pair from LRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(T key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates the key/value pair position on first in LRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public void Update(T key)
        {
            var node = lruListCache.Single(node => EqualityComparer<T>.Default.Equals(node.Key, key));
            lruListCache.Remove(node);
            lruListCache.AddFirst(node);
        }
        /// <summary>
        /// Gets value from LRU cache list, created only for unit tests.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value</returns>
        public T GetValue(T key)
        {
            return lruListCache.Single(node => EqualityComparer<T>.Default.Equals(node.Key, key)).Value;
        }
        /// <summary>
        /// Determines key/value pair position in LRU cache list, created only for unit tests.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetKeyValueHashMapOrder(T key)
        {
            throw new NotImplementedException();
        }
    }

}
