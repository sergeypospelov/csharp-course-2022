using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTable<TK, TV>
    {
        private enum Status
        {
            Empty = 0,
            Used = 1,
            Deleted = 2,
        }

        private struct Node
        {
            public TK Key;
            public readonly TV Value;
            public Status Status;

            public Node(TK key, TV value)
            {
                Key = key;
                Value = value;
                Status = Status.Used;
            }

            public void Deconstruct(out TK key, out TV value, out Status status)
            {
                key = Key;
                value = Value;
                status = Status;
            }
        }

        private const int InitialCapacity = 100;

        private uint _capacity;
        private Node[] _storage;
        private uint _size;
        private uint _used;
    
        public HashTable(uint initialCapacity = InitialCapacity)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentException("InitialCapacity must be greater than 0");
            }

            _capacity = initialCapacity;
            _storage = new Node[_capacity];
            _size = 0;
            _used = 0;
        }

        public void Add(TK key, TV value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            bool contains = ContainsKey(key);
            var idx = SearchKey(key, !contains);

            switch (_storage[idx].Status)
            {
                case Status.Empty:
                    _size++;
                    _used++;
                    break;
                case Status.Used:
                    break;
                case Status.Deleted:
                    _size++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _storage[idx] = new Node(key, value);

            if (_used * 2 >= _capacity)
            {
                Rebuild();
            }
        }

        public bool ContainsKey(TK key)
        {
            uint idx = SearchKey(key, false);
            return _storage[idx].Status == Status.Used && _storage[idx].Key.Equals(key);
        }
    
        public void Remove(TK key)
        {
            uint idx = SearchKey(key, false);
            if (_storage[idx].Status != Status.Used)
            {
                throw new KeyNotFoundException(key.ToString());
            }
        
            _size--;

            _storage[idx].Status = Status.Deleted;
        }

        public TV Get(TK key)
        {
            uint idx = SearchKey(key, false);
            if (_storage[idx].Status != Status.Used)
            {
                throw new KeyNotFoundException(key.ToString());
            }
            return _storage[idx].Value;
        }

        public uint Size()
        {
            return _size;
        }

        private uint SearchKey(TK key, bool treatDeletedAsEmpty)
        {
            for (var time = 0u;; time++)
            {
                var idx = GetIdx(key, time);
                if ((_storage[idx].Status == Status.Deleted && treatDeletedAsEmpty)
                    || (_storage[idx].Status == Status.Used && _storage[idx].Key.Equals(key))
                    || _storage[idx].Status == Status.Empty)
                    return idx;
            }
        }

        private uint GetIdx(TK key, uint time)
        {
            var idx = ((uint)key.GetHashCode() + (ulong)time * time) % _capacity;
            return (uint)idx;
        }

        private void Rebuild()
        {
            var newCapacity = _capacity * 2;
            var newHashTable = new HashTable<TK, TV>(newCapacity);

            foreach (var (k, v, s) in _storage)
            {
                if (s == Status.Used)
                {
                    newHashTable.Add(k, v);
                }
            }

            SetFromOther(newHashTable);
        }
    
        private void SetFromOther(HashTable<TK, TV> other)
        {
            _capacity = other._capacity;
            _storage = other._storage;
            _size = other._size;
            _used = other._used;
        }
    }
}