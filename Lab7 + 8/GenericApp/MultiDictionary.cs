using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        private Dictionary<K, LinkedList<V>> _dictionary;

        public MultiDictionary()
        {
            _dictionary = new Dictionary<K, LinkedList<V>>();
        }

        public void Add(K key, V value)
        {
            LinkedList<V> list=null;
            

            if (_dictionary.TryGetValue(key, out list) == false)
            {
                list = new LinkedList<V>();
                list.AddLast(value);
                _dictionary.Add(key, list);
            }
            else
            {
                list.AddLast(value);
            }
        }

        public bool Remove(K key)
        {
            return _dictionary.Remove(key);
        }

        public bool Remove(K key, V value)
        {
            LinkedList<V> list;
            
            if (_dictionary.TryGetValue(key,out list) == false)
            {
                return false;
            }
            return list.Remove(value);
        }

        public void Clear()
        {
            System.Collections.Generic.ICollection<K> keys = _dictionary.Keys;
            foreach (K key in keys)
            {
                _dictionary.Remove(key);
            }
        }

        public bool ContainsKey(K key)
        {
            System.Collections.Generic.ICollection<K> keys = this.Keys;

            return keys.Contains(key);
        }

        public bool Contains(K key, V value)
        {
            LinkedList<V> list;
            if (_dictionary.TryGetValue(key, out list) == false)
            {
                return false;
            }

            return list.Contains(value);
        }

        public ICollection<K> Keys
        {
            get { return _dictionary.Keys; }
        }

        public ICollection<V> Values
        {
            get 
            {
                List<V> allValues = new List<V>();
                LinkedList<V> list;
                System.Collections.Generic.ICollection<K> keys = this.Keys;
                bool attempt;
                foreach (K key in keys)
                {
                    attempt = _dictionary.TryGetValue(key, out list);
                    if (attempt==true)
                    {
                        allValues.AddRange(list);
                    }
                }
                return allValues;
            }
        }

        public int Count
        {
            get 
            {
                int count = 0;
                LinkedList<V> list;
                System.Collections.Generic.ICollection<K> keys = _dictionary.Keys;
                foreach (K key in keys)
                {
                    if (_dictionary.TryGetValue(key, out list)==true)
                    {
                        count+=list.Count;
                    }
                }
                return count;
            }
        }


        // in the following method create a list of <K,V> pairs and return an enumerator to it
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();
            System.Collections.Generic.ICollection<K> keys = this.Keys;
            LinkedList<V> tempList;
            
            foreach(K key in keys)
            {
                
                if (_dictionary.TryGetValue(key, out tempList) == true)
                {
                    foreach (V val in tempList)
                    {
                        list.Add(new KeyValuePair<K, V>(key, val));
                    }
                }
            }
            
            return list.GetEnumerator();
        }

        // in the following method return the result of the previous method
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
