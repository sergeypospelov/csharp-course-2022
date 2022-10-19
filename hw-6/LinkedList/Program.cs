using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    class MyList<T> : IEnumerable<T>
    {
        class ListNode
        {
            public T Value { get; }
            public ListNode Next { get; private set; }

            internal ListNode(T value)
            {
                Value = value;
                Next = null;
            }

            public void Add(ListNode node)
            {
                Next = node;
            }
        }

        private ListNode _head;
        private ListNode _tail;
        public int Count { get; private set; }

        public MyList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void Add(T val)
        {
            var node = new ListNode(val);
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Add(node);
                _tail = node;
            }

            Count++;
        }

        public bool Remove(T elem)
        {
            if (Equals(_head.Value, elem))
            {
                _head = _head.Next;
                if (_head == null)
                {
                    _tail = null;
                }

                Count--;
                return true;
            }

            var cur = _head;

            while (cur != null)
            {
                var nxt = cur.Next;
                if (nxt != null && Equals(nxt.Value, elem))
                {
                    cur.Add(nxt.Next);
                    if (_tail == nxt)
                    {
                        _tail = cur;
                    }

                    Count--;
                    return true;
                }

                cur = cur.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var cur = _head;
            while (cur != null)
            {
                yield return cur.Value;
                cur = cur.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var list = new MyList<int>();

            list.Add(3);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Console.Out.WriteLine("Size: " + list.Count);
            Console.Out.WriteLine("Remove 2:" + list.Remove(2));
            Console.Out.WriteLine("Size: " + list.Count);
            Console.Out.WriteLine("Remove 2:" + list.Remove(2));
            Console.Out.WriteLine("Size: " + list.Count);
            Console.Out.WriteLine("Remove 2:" + list.Remove(4));
            Console.Out.WriteLine("Size: " + list.Count);

            list.Add(4);
            list.Add(1);
            list.Add(4);

            Console.Out.WriteLine("Size: " + list.Count);

            foreach (var i in list)
            {
                Console.Out.Write(i + " ");
            }

            Console.Out.WriteLine("\nRemove 4:" + list.Remove(4));

            Console.Out.WriteLine("Size: " + list.Count);
            foreach (var i in list)
            {
                Console.Out.Write(i + " ");
            }
        }
    }
}