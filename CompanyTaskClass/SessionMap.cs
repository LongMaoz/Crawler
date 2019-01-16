using System;
using System.Collections.Generic;

namespace CompanyTaskClass
{
    public class SessionMap<K,V>
    {
        private static Dictionary<K, V> dict = new Dictionary<K, V>();

        public V this[K key]
        {
            set { dict[key] = value; }
            get { return dict[key]; }
        }

        public void Remove(K key)
        {
            dict.Remove(key);
        }
    }
}
