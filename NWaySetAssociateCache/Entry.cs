using System;
using System.Collections.Generic;
using System.Text;

namespace NWaySetAssociateCache
{
    public class Entry<T>
    {
        private T _key;
        private T _value;
        public Entry(T key, T value)
        {
            _key = key;
            _value = value;
        }
        public T Key
        {
            get { return _key; }
        }
        public T Value
        {
            get { return _value; }
        }
    }
}
