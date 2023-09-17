using Lab1;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionary
{
    class Dictionary<TKey, TValue> : IEnumerable
    {
        private int size = 100;
        private Item<TKey, TValue>[] Items;
        private List<TKey> Keys = new List<TKey>();

        public Dictionary()
        {
            Items = new Item<TKey, TValue>[size];
        }

        public void Add(Item<TKey, TValue> item)
        {
            var hash = GetHash(item.Key);

            if (Keys.Contains(item.Key))
            {
                return;
            }

            if (Items[hash] == null)
            {
                Keys.Add(item.Key);
                Items[hash] = item;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (Items[i] == null)
                    {
                        Keys.Add(item.Key);
                        Items[i] = item;
                        placed = true;
                        break;
                    }

                    if (Items[i].Key.Equals(item.Key))
                    {
                        return;
                    }
                }

                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (Items[i] == null)
                        {
                            Keys.Add(item.Key);
                            Items[i] = item;
                            placed = true;
                            break;
                        }

                        if (Items[i].Key.Equals(item.Key))
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

        public void Remove(TKey key)
        {
            var hash = GetHash(key);

            if (!Keys.Contains(key))
            {
                return;
            }

            if (Items[hash] == null)
            {
                for (var i = 0; i < size; i++)
                {
                    if (Items[i] != null && Items[i].Key.Equals(key))
                    {
                        Items[i] = null;
                        Keys.Remove(key);
                        return;
                    }
                }

                return;
            }

            if (Items[hash].Key.Equals(key))
            {
                Items[hash] = null;
                Keys.Remove(key);
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (Items[i] == null)
                    {
                        return;
                    }

                    if (Items[i].Key.Equals(key))
                    {
                        Items[i] = null;
                        Keys.Remove(key);
                        return;
                    }
                }

                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (Items[i] == null)
                        {
                            return;
                        }

                        if (Items[i].Key.Equals(key))
                        {
                            Items[i] = null;
                            Keys.Remove(key);
                            return;
                        }
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }
    }
}
