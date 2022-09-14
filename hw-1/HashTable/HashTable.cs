using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    public class HashTable<TK, TV>
    {
        private const int DefaultCapacity = 100;
        
        private readonly List<KeyValuePair<TK, TV>> []_table;

        public HashTable(int capacity = DefaultCapacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException($"Capacity must be greater than zero, got {capacity}");
            }
            _table = Enumerable.Range(0, capacity).Select(_ => new List<KeyValuePair<TK, TV>>()).ToArray();
        }

        public void Remove(TK key)
        {
            var index = ComputeBaseIndex(key);
            _table[index].RemoveAll(pr => pr.Key.Equals(key));
            
        }

        public void Add(TK key, TV value)
        {
            Remove(key);
            var index = ComputeBaseIndex(key);
            _table[index].Add(new KeyValuePair<TK, TV>(key, value));
        }

        public bool Exists(TK key)
        {
            var index = ComputeBaseIndex(key);
            return _table[index].Exists(pr => pr.Key.Equals(key));
        }

        public TV Get(TK key)
        {
            if (!Exists(key))
            {
                return default;
            }
            var index = ComputeBaseIndex(key);
            var value = _table[index].Find(pr => pr.Key.Equals(key));
            return value.Value;
        }

        private int ComputeBaseIndex(TK key)
        {
            return (key.GetHashCode() % _table.Length + _table.Length) % _table.Length;
        }
    }
}