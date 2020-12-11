using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWaySetAssociateCache
{
    public class MRUAlgorithm<KeyType, ValueType> : Algorithm<KeyType, ValueType>
    {
        /// <summary>
        /// Constructor for MRU Algorithm.
        /// </summary>
        public MRUAlgorithm() : base() { }

        /// <summary>
        /// Adds key/value pair to MRU cache list.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public override void Add(KeyType key, ValueType value)
        {
            CacheList.AddLast(new KeyValuePair<KeyType, ValueType>(key, value));
        }

        /// <summary>
        /// Removes key/value pair from MRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public override void Remove()
        {
            CacheList.RemoveLast();
        }

        /// <summary>
        /// Updates the key/value pair position on first in MRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public override void Update(KeyType key)
        {
            var node = CacheList.Single(node => EqualityComparer<KeyType>.Default.Equals(node.Key, key));
            if (!IsKeyValuePairLast(key))
            {
                CacheList.Remove(node);
                CacheList.AddLast(node);
            }
        }

        public bool IsKeyValuePairLast(KeyType key)
        {
            return CacheList.Last().Key.Equals(key);
        }

        /// <summary>
        /// Gives Key to Remove
        /// </summary>
        /// <returns></returns>
        public override KeyType GetKeyToRemove()
        {
            return CacheList.Last().Key;
        }
    }
}
