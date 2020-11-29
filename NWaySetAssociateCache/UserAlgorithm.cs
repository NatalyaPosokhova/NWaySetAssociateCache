using System;
using System.Collections.Generic;
using System.Text;

namespace NWaySetAssociateCache
{
    public class UserAlgorithm<KeyType, ValueType> : Algorithm<KeyType, ValueType>
    {
        /// <summary>
        /// Constructor for User Algorithm.
        /// </summary>
        public UserAlgorithm() : base() { }

        /// <summary>
        /// Adds key/value pair to User cache list.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public override void Add(KeyType key, ValueType value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes key/value pair from User cache list.
        /// </summary>
        public override void Remove()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the key/value pair position on first in User cache list.
        /// </summary>
        /// <param name="key"></param>
        public override void Update(KeyType key)
        {
            throw new NotImplementedException();
        }
    }
}
