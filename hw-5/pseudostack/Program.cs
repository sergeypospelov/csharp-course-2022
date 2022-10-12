using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace pseudostack
{
    internal class Program
    {
        class PseudoStack<T> : IEnumerable<T>
        {
            private readonly List<List<T>> _stack = new List<List<T>>();
            public readonly int MaxSingleCapacity;

            public PseudoStack(int maxSingleCapacity)
            {
                if (maxSingleCapacity < 1)
                {
                    throw new ArgumentException("maxSingleCapacity must be greater than zero");
                }
                
                MaxSingleCapacity = maxSingleCapacity;
                _stack.Add(new List<T>());
            }

            public void Push(T value)
            {
                _stack.Last().Add(value);

                if (_stack.Last().Count == MaxSingleCapacity)
                {
                    _stack.Add(new List<T>());
                }
            }

            public T Pop()
            {
                if (_stack.Last().Count == 0)
                {
                    _stack.RemoveAt(_stack.Count - 1);
                }

                var idx = _stack.Last().Count - 1;
                var remv = _stack.Last()[idx];
                _stack.Last().RemoveAt(idx);
                return remv;
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (var block in _stack)
                {
                    foreach (var i in block)
                    {
                        yield return i;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        
        public static void Main(string[] args)
        {
            var stack = new PseudoStack<int>(3);
            
            stack.Push(14);
            stack.Push(15);
            stack.Push(42);

            Console.Out.WriteLine(String.Join(" ", stack));
            
            stack.Push(100);
            stack.Push(0);
            
            Console.Out.WriteLine(String.Join(" ", stack));

            stack.Pop();

            Console.Out.WriteLine(String.Join(" ", stack));

            stack.Pop();
            stack.Pop();
            stack.Pop();
        
            Console.Out.WriteLine(String.Join(" ", stack));
        }
    }
}