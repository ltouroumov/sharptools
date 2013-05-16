using System;
using System.Linq;
using System.Collections.Generic;
using Windows.Foundation.Collections;
using System.ComponentModel;

namespace Utils.Containers
{
    public static class DictionaryExtensions
    {
        public static V GetValueOrDefault<K, V>(this IDictionary<K, V> self, K key, Func<K, V> def)
        {
            V val;
            if (self.TryGetValue(key, out val)) {
                return val;
            } else {
                return def.Invoke(key);
            }
        }
    }

    public class ObservableValue<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private T _value = default(T);

        public T Value {
            get { return _value; }
            set { _value = value; NotifyChange("Value"); }
        }

        protected void NotifyChange(string prop)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }

    /// <summary>
    /// Implementation of IObservableMap that supports reentrancy for use as a default view
    /// model.
    /// </summary>
    public class ObservableMap<K, V> : IObservableMap<K, V>, IDictionary<K, V>, INotifyPropertyChanged
    {
        private Dictionary<K, V> _dictionary = new Dictionary<K, V>();
        public event MapChangedEventHandler<K, V> MapChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokeMapChanged(CollectionChange change, K key)
        {
            if (MapChanged != null) {
                MapChanged(this, new ObservableMapChangedEventArgs<K>(change, key));
            }
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(key as string));
            }
        }

        public void Add(K key, V value)
        {
            this._dictionary.Add(key, value);
            this.InvokeMapChanged(CollectionChange.ItemInserted, key);
        }

        public void Add(KeyValuePair<K, V> item)
        {
            this.Add(item.Key, item.Value);
        }

        public bool Remove(K key)
        {
            if (this._dictionary.Remove(key)) {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
                return true;
            }
            return false;
        }

        public bool Remove(KeyValuePair<K, V> item)
        {
            V currentValue;
            if (this._dictionary.TryGetValue(item.Key, out currentValue) &&
                Object.Equals(item.Value, currentValue) && this._dictionary.Remove(item.Key)) {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, item.Key);
                return true;
            }
            return false;
        }

        public V this[K key]
        {
            get
            {
                return this._dictionary[key];
            }
            set
            {
                this._dictionary[key] = value;
                this.InvokeMapChanged(CollectionChange.ItemChanged, key);
            }
        }

        public void Clear()
        {
            var priorKeys = this._dictionary.Keys.ToArray();
            this._dictionary.Clear();
            foreach (var key in priorKeys) {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
            }
        }

        public ICollection<K> Keys
        {
            get { return this._dictionary.Keys; }
        }

        public bool ContainsKey(K key)
        {
            return this._dictionary.ContainsKey(key);
        }

        public bool TryGetValue(K key, out V value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<V> Values
        {
            get { return this._dictionary.Values; }
        }

        public bool Contains(KeyValuePair<K, V> item)
        {
            return this._dictionary.Contains(item);
        }

        public int Count
        {
            get { return this._dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            int arraySize = array.Length;
            foreach (var pair in this._dictionary) {
                if (arrayIndex >= arraySize) break;
                array[arrayIndex++] = pair;
            }
        }
    }

    public class ObservableMapChangedEventArgs<K> : IMapChangedEventArgs<K>
    {
        public ObservableMapChangedEventArgs(CollectionChange change, K key)
        {
            this.CollectionChange = change;
            this.Key = key;
        }

        public CollectionChange CollectionChange { get; private set; }
        public K Key { get; private set; }
    }

}