using System;
using System.Collections.Generic;
using System.Text;

namespace NWaySetAssociateCache
{
    public abstract class Algorithm<T>
    {
        protected LinkedList<KeyValuePair<T, T>> CacheList { get; private set; }
        /// <summary>
        /// Constructor for Algorithm of clearing cache.
        /// </summary>
        public Algorithm()
        {
            CacheList = new LinkedList<KeyValuePair<T, T>>();
        }

        /// <summary>
        /// Adds key/value pair to cache list.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public abstract void Add(T key, T value);

        /// <summary>
        /// Updates the key/value pair position in cache list.
        /// </summary>
        /// <param name="key"></param>
        public abstract void Update(T key);

        /// <summary>
        /// Removes key/value pair from cache list.
        /// </summary>
        public abstract void Remove();
    }
}
