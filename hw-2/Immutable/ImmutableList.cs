using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Immutable
{
    public class ImmutableList<T> : IEnumerable<T>
    {

        private readonly List<T> list_;

        public ImmutableList(List<T> list)
        {
            list_ = list;
        }

        public int Count => list_.Count;

        public ImmutableList<T> Add(T val)
        {
            var list = list_.ToList();
            list.Add(val);
            return new ImmutableList<T>(list);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list_[i];
            }
        }

        public ImmutableList<T> Remove(T val)
        {
            var list = list_.ToList();
            list.Remove(val);
            return new ImmutableList<T>(list);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}