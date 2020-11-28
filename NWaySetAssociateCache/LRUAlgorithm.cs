using System;
using System.Collections.Generic;
using System.Linq;

namespace NWaySetAssociateCache
{
    public class LRUAlgorithm<T> : Algorithm<T>
    {
        /// <summary>
        /// Constructor for LRU Algorithm of clearing cache.
        /// </summary>
        /// <param name="cacheSize"></param>
        public LRUAlgorithm() : base() { }
  
        /// <summary>
        /// Adds key/value pair to LRU cache list.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public override void Add(T key, T value)
        {
            LruListCache.AddFirst(new KeyValuePair<T, T>(key, value));
        }
        /// <summary>
        /// Removes key/value pair from LRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public override void Remove()
        {
            LruListCache.RemoveLast();
        }
        /// <summary>
        /// Updates the key/value pair position on first in LRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public override void Update(T key)
        {
            var node = LruListCache.Single(node => EqualityComparer<T>.Default.Equals(node.Key, key));
            if (!IsKeyValuePairFirst(key))
            {
                LruListCache.Remove(node);
                LruListCache.AddFirst(node);
            }
        }
        /// <summary>
        /// Gets value from LRU cache list, created only for unit tests.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value</returns>
        public T GetValue(T key)
        {
            return LruListCache.Single(node => EqualityComparer<T>.Default.Equals(node.Key, key)).Value;
        }
        /// <summary>
        /// Determines if key/value pair position in LRU cache list is first.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyValuePairFirst(T key)
        {
            return LruListCache.First().Key.Equals(key);
        }
    }

}
