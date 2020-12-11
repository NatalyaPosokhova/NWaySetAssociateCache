using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWaySetAssociateCache
{
    public abstract class Algorithm<KeyType, ValueType>
    {
        protected LinkedList<KeyValuePair<KeyType, ValueType>> CacheList { get; private set; }
        /// <summary>
        /// Constructor for Algorithm of clearing cache.
        /// </summary>
        public Algorithm()
        {
            CacheList = new LinkedList<KeyValuePair<KeyType, ValueType>>();
        }

        /// <summary>
        /// Adds key/value pair to cache list.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public abstract void Add(KeyType key, ValueType value);

        /// <summary>
        /// Updates the key/value pair position in cache list.
        /// </summary>
        /// <param name="key"></param>
        public abstract void Update(KeyType key);

        /// <summary>
        /// Removes key/value pair from cache list.
        /// </summary>
        /// <param name="removeAlgorithm"></param>
        public abstract void Remove();

        /// <summary>
        /// Gives key to remove.
        /// </summary>
        /// <returns></returns>
        public abstract KeyType GetKeyToRemove();

        /// <summary>
        /// Gets value from cache list, created only for unit tests.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value</returns>
        public ValueType GetValue(KeyType key)
        {
            return CacheList.Single(node => EqualityComparer<KeyType>.Default.Equals(node.Key, key)).Value;
        }
    }
}
