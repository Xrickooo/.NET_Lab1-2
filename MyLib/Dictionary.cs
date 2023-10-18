using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLib
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int _size = 100;
        private readonly Item<TKey, TValue>[] _items;
        private readonly List<TKey> _keys = new List<TKey>();

        public event Action<TKey, TValue> OnItemAdded;
        public event Action<TKey> OnItemRemoved;
        public event Action OnDictionaryCleared;

        public MyDictionary()
        {
            _items = new Item<TKey, TValue>[_size];
        }

        public TValue this[TKey key]
        {
            get => Search(key);
            set
            {
                Add(key, value);
                OnItemAdded?.Invoke(key, value);
            }
        }

        public ICollection<TKey> Keys => _keys;

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();
                foreach (var item in _items)
                {
                    if (item != null)
                    {
                        values.Add(item.Value);
                    }
                }
                return values;
            }
        }

        public int Count => _keys.Count;

        public bool IsReadOnly => false;

        public TValue Search(TKey key)
        {
            if (_keys.Contains(key))
            {
                var hash = GetHash(key);
                for (var i = 0; i < _size; i++)
                {
                    var index = (hash + i) % _size;
                    if (_items[index] != null && _items[index].Key.Equals(key))
                    {
                        return _items[index].Value;
                    }
                }
            }

            throw new KeyNotFoundException($"Key '{key}' not found in the dictionary.");
        }



        public void Add(TKey key, TValue value)
        {
            var hash = GetHash(key);

            if (hash < 0)
            {
                throw new ArgumentException($"Hash value for key '{key}' is less than 0.");
            }

            if (_keys.Contains(key))
            {
                throw new ArgumentException($"Key '{key}' already exists in the dictionary.");
            }

            int index = hash;
            while (_items[index] != null)
            {
                index = (index + 1) % _size;
                if (index == hash)
                {
                    throw new Exception("Out of dictionary range");
                }
            }

            _keys.Add(key);
            _items[index] = new Item<TKey, TValue> { Key = key, Value = value };
            OnItemAdded?.Invoke(key, value);
        }



        public bool Remove(TKey key)
        {
            var hash = GetHash(key);

            if (!_keys.Contains(key))
            {
                throw new InvalidOperationException($"Key '{key}' not found.");
            }

            for (var i = 0; i < _size; i++)
            {
                var index = (hash + i) % _size;
                if (_items[index] != null && _items[index].Key.Equals(key))
                {
                    _items[index] = null;
                    _keys.Remove(key);
                    OnItemRemoved?.Invoke(key);
                    return true;
                }
            }

            throw new InvalidOperationException($"Key '{key}' not found.");
        }



        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default;

            var hash = GetHash(key);

            if (!_keys.Contains(key))
            {
                throw new InvalidOperationException($"Key '{key}' not found.");
            }

            int index = hash;
            while (_items[index] != null)
            {
                if (_items[index].Key.Equals(key))
                {
                    value = _items[index].Value;
                    return true;
                }
                index = (index + 1) % _size;
            }

            throw new InvalidOperationException($"Key '{key}' not found.");
        }



        private int GetHash(TKey key)
        {
            return key.GetHashCode() % _size;
        }

        public void Clear()
        {
            var keysCopy = new List<TKey>(Keys);

            foreach (var key in keysCopy)
            {
                Remove(key);
            }

            OnDictionaryCleared?.Invoke();
        }

        public bool ContainsKey(TKey key)
        {
            foreach (var item in _items)
            {
                if (item != null && item.Key.Equals(key))
                {
                    return true;
                }
            }

            throw new KeyNotFoundException($"$Key '{key}' not found.");
        }

        public bool ContainsValue(TValue value)
        {
            foreach (var item in _items)
            {
                if (item != null && EqualityComparer<TValue>.Default.Equals(item.Value, value))
                {
                    return true;
                }
            }

            throw new Exception($"Value '{value}' not found.");
        }

        public void TryAdd(Item<TKey, TValue> item)
        {
            if (_keys.Contains(item.Key))
            {
                throw new InvalidOperationException($"Key '{item.Key}' already exists.");
            }

            Add(item.Key, item.Value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (_keys.Contains(item.Key))
            {
                Remove(item.Key);
                return true;
            }
            else
            {
                throw new Exception("Item not found.");
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var key in _keys)
            {
                var hash = GetHash(key);
                yield return new KeyValuePair<TKey, TValue>(key, _items[hash].Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            foreach (var key in _keys)
            {
                var hash = GetHash(key);
                var currentItem = _items[hash];

                if (currentItem != null && currentItem.Key.Equals(item.Key) && EqualityComparer<TValue>.Default.Equals(currentItem.Value, item.Value))
                {
                    return true;
                }
            }

            throw new Exception("Item not found.");
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (array.Length - arrayIndex < _keys.Count)
            {
                throw new ArgumentException("The destination array is not large enough.", nameof(array));
            }

            int i = arrayIndex;
            foreach (var key in _keys)
            {
                var hash = GetHash(key);
                var currentItem = _items[hash];

                if (currentItem != null)
                {
                    array[i++] = new KeyValuePair<TKey, TValue>(currentItem.Key, currentItem.Value);
                }
            }
        }


    }
}
