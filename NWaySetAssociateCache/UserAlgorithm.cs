using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWaySetAssociateCache
{
    public class UserAlgorithm<KeyType, ValueType> : Algorithm<KeyType, ValueType>
    {
        private Func<KeyType, UpdateAction> _updateAct;
        private Func<KeyType, ValueType, AddAction> _addAct;
        private Func<RemoveAction> _removeAct;

        /// <summary>
        /// Constructor for User Algorithm.
        /// </summary>
        public UserAlgorithm(Func<KeyType, UpdateAction> updateAct, Func<KeyType, ValueType, AddAction> addAct, Func<RemoveAction> removeAct)
        {
            _updateAct = updateAct;
            _addAct = addAct;
            _removeAct = removeAct;
        }

        
        /// <summary>
        /// Adds key/value pair to User cache list.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public override void Add(KeyType key, ValueType value)
        {
            var node = CacheList.Single(node => EqualityComparer<KeyType>.Default.Equals(node.Key, key));
            if (_addAct(key, value) == AddAction.addToFirst)
            {
                CacheList.AddFirst(node);
            }
            else
            {
                CacheList.AddLast(node);
            }
        }

        /// <summary>
        /// Gives Key to Remove
        /// </summary>
        /// <returns></returns>
        public override KeyType GetKeyToRemove()
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

    public enum UpdateAction 
    { 
        moveToFirst, 
        moveToEnd, 
        nothing 
    }

    public enum AddAction
    {
        addToFirst,
        addToLast
    }

    public enum RemoveAction
    {
        removeFirst,
        removeLast
    }

}
