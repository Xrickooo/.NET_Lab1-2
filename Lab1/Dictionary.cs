using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int _size = 100;
        private readonly Item<TKey, TValue>[] _items;
        private readonly List<TKey> _keys = new List<TKey>();

        public event Action<TKey, TValue> ItemAdded;
        public event Action<TKey> ItemRemoved;
        public event Action DictionaryCleared;

        public void SubscribeToEvents()
        {
            ItemAdded += (key, value) => Console.WriteLine($"Element with key {key} and value {value} added.");
            ItemRemoved += key => Console.WriteLine($"Element with key {key} is removed.");
            DictionaryCleared += () => Console.WriteLine("Dictionary is cleared.");
        }

        public MyDictionary()
        {
            _items = new Item<TKey, TValue>[_size];
            SubscribeToEvents();
        }

        public TValue this[TKey key]
        {
            get => Search(key);
            set
            {
                Add(key, value);
                ItemAdded?.Invoke(key, value);
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
            var hash = GetHash(key);

            if (_keys.Contains(key))
            {
                if (_items[hash] == null)
                {
                    foreach (var item in _items)
                    {
                        if (item != null && item.Key.Equals(key))
                        {
                            return item.Value;
                        }
                    }
                }
                else if (_items[hash].Key.Equals(key))
                {
                    return _items[hash].Value;
                }
                else
                {
                    var placed = false;
                    for (var i = hash; i < _size; i++)
                    {
                        if (_items[i] == null)
                        {
                            break;
                        }

                        if (_items[i].Key.Equals(key))
                        {
                            return _items[i].Value;
                        }
                    }

                    for (var i = 0; i < hash; i++)
                    {
                        if (_items[i] == null)
                        {
                            break;
                        }

                        if (_items[i].Key.Equals(key))
                        {
                            return _items[i].Value;
                        }
                    }
                }
            }

            throw new KeyNotFoundException($"Key '{key}' not found in the dictionary.");
        }


        public void Add(TKey key, TValue value)
        {
            var hash = GetHash(key);

            if (_keys.Contains(key))
            {
                throw new ArgumentException($"Key '{key}' already exists in the dictionary.");
            }
            if (_items[hash] == null)
            {
                _keys.Add(key);
                _items[hash] = new Item<TKey, TValue> { Key = key, Value = value };
                ItemAdded?.Invoke(key, value);
            }
            else
            {
                var placed = false;
                for (var i = hash; i < _size; i++)
                {
                    if (_items[i] == null)
                    {
                        _keys.Add(key);
                        _items[i] = new Item<TKey, TValue> { Key = key, Value = value };
                        placed = true;
                        ItemAdded?.Invoke(key, value);
                        break;
                    }

                    if (_items[i].Key.Equals(key))
                    {
                        return;
                    }
                }

                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (_items[i] == null)
                        {
                            _keys.Add(key);
                            _items[i] = new Item<TKey, TValue> { Key = key, Value = value };
                            placed = true;
                            ItemAdded?.Invoke(key, value);
                            break;
                        }

                        if (_items[i].Key.Equals(key))
                        {
                            return;
                        }
                    }
                }

                if (!placed)
                {
                    throw new Exception("Out of dictionary range");
                }
            }
        }

        public bool Remove(TKey key)
        {
            var hash = GetHash(key);

            if (!_keys.Contains(key))
            {
                throw new InvalidOperationException($"$Key '{key}' not found.");
            }
            if (_items[hash] == null)
            {
                for (var i = 0; i < _size; i++)
                {
                    if (_items[i] != null && _items[i].Key.Equals(key))
                    {
                        _items[i] = null;
                        _keys.Remove(key);
                        ItemRemoved?.Invoke(key);
                        return true;
                    }
                }

                throw new InvalidOperationException($"$Key '{key}' not found.");
            }

            if (_items[hash].Key.Equals(key))
            {
                _items[hash] = null;
                _keys.Remove(key);
                ItemRemoved?.Invoke(key);
                return true;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < _size; i++)
                {
                    if (_items[i] == null)
                    {
                        throw new InvalidOperationException($"$Key '{key}' not found.");
                    }

                    if (_items[i].Key.Equals(key))
                    {
                        _items[i] = null;
                        _keys.Remove(key);
                        ItemRemoved?.Invoke(key);
                        return true;
                    }
                }

                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (_items[i] == null)
                        {
                            throw new InvalidOperationException($"$Key '{key}' not found.");
                        }

                        if (_items[i].Key.Equals(key))
                        {
                            _items[i] = null;
                            _keys.Remove(key);
                            ItemRemoved?.Invoke(key);
                            return true;
                        }
                    }
                }

                throw new InvalidOperationException($"$Key '{key}' not found.");
            }
        }


        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            var hash = GetHash(key);

            if (!_keys.Contains(key))
            {
                throw new InvalidOperationException($"$Key '{key}' not found.");
            }
            if (_items[hash] == null)
            {
                foreach (var item in _items)
                {
                    if (item != null && item.Key.Equals(key))
                    {
                        value = item.Value;
                        return true;
                    }
                }

                throw new InvalidOperationException($"$Key '{key}' not found.");
            }

            if (_items[hash].Key.Equals(key))
            {
                value = _items[hash].Value;
                return true;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < _size; i++)
                {
                    if (_items[i] == null)
                    {
                        throw new InvalidOperationException($"$Key '{key}' not found.");
                    }

                    if (_items[i].Key.Equals(key))
                    {
                        value = _items[i].Value;
                        return true;
                    }
                }

                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (_items[i] == null)
                        {
                            throw new InvalidOperationException($"$Key '{key}' not found.");
                        }

                        if (_items[i].Key.Equals(key))
                        {
                            value = _items[i].Value;
                            return true;
                        }
                    }
                }
            }

            throw new InvalidOperationException($"$Key '{key}' not found.");
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

            DictionaryCleared?.Invoke();
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
                throw new ArgumentException("The destination array is not large enough.");
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


