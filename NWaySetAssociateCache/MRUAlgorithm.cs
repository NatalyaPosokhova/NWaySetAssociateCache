using System;
using System.Collections.Generic;
using System.Text;

namespace NWaySetAssociateCache
{
    public class MRUAlgorithm<T> : Algorithm<T>
    {
        public MRUAlgorithm() : base() { }

        /// <summary>
        /// Adds key/value pair to MRU cache list.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public override void Add(T key, T value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Removes key/value pair from MRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public override void Remove()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates the key/value pair position on first in MRU cache list.
        /// </summary>
        /// <param name="key"></param>
        public override void Update(T key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets value from MRU cache list, created only for unit tests.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value</returns>
        public T GetValue(T key)
        {
            throw new NotImplementedException();
        }

        public bool? IsKeyValuePairLast(string key1)
        {
            throw new NotImplementedException();
        }
    }
}
