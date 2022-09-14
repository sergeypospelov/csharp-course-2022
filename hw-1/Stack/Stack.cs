using System;
using System.Collections;

namespace Stack
{
    public class Stack<T> where T : IComparable
    {
        private class Node
        {
            public T Value { get;  }
            public T Min { get; }

            public Node(T val)
            {
                Value = val;
                Min = val;
            }

            public Node(Node other, T val)
            {
                Value = val;
                Min = val;
                if (other.Min.CompareTo(val) < 0)
                {
                    Min = other.Min;
                }
            }
        }

        private System.Collections.Generic.Stack<Node> _stck;

        public Stack()
        {
            _stck = new System.Collections.Generic.Stack<Node>();
        }

        public void Push(T x)
        {
            var node = _stck.Count == 0 ? new Node(x) : new Node(_stck.Peek(), x);
            _stck.Push(node);
        }

        public T Pop()
        {
            var node = _stck.Pop();
            return node.Value;
        }

        public T MinValue()
        {
            var node = _stck.Peek();
            return node.Min;
        }
    }
}