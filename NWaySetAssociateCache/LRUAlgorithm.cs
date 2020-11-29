using System;
using System.Collections.Generic;
using System.Linq;

namespace NWaySetAssociateCache
{
    public class LRUAlgorithm<KeyType, ValueType> : Algorithm<KeyType, ValueType>
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
        public override sealed void Add(KeyType key, ValueType value)
        {
            CacheList.AddFirst(new KeyValuePair<KeyType, ValueType>(key, value));
        }
        /// <summary>
        /// Removes key/value pair from LRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public override sealed void Remove()
        {
            CacheList.RemoveLast();
        }
        /// <summary>
        /// Updates the key/value pair position on first in LRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public override sealed void Update(KeyType key)
        {
            var node = CacheList.Single(node => EqualityComparer<KeyType>.Default.Equals(node.Key, key));
            if (!IsKeyValuePairFirst(key))
            {
                CacheList.Remove(node);
                CacheList.AddFirst(node);
            }
        }
        /// <summary>
        /// Gets value from LRU cache list, created only for unit tests.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value</returns>
        public ValueType GetValue(KeyType key)
        {
            return CacheList.Single(node => EqualityComparer<KeyType>.Default.Equals(node.Key, key)).Value;
        }
        /// <summary>
        /// Determines if key/value pair position in LRU cache list is first.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyValuePairFirst(KeyType key)
        {
            return CacheList.First().Key.Equals(key);
        }
    }

}
