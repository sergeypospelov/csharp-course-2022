using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Matrix
{
    class Matrix<T> : IEnumerable<T>
    {
        private readonly Dictionary<Tuple<int, int, int>, T> _data;

        public Matrix()
        {
            _data = new Dictionary<Tuple<int, int, int>, T>();
        }

        public T this[int i, int j, int k]
        {
            get => _data[new Tuple<int, int, int>(i, j, k)];
            set => _data[new Tuple<int, int, int>(i, j, k)] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.Values.GetEnumerator();
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
            var matrix = new Matrix<int>();

            matrix[1, 2, 3] = 5;
            matrix[1, 2, 4] = 10;
            matrix[1, 2, 3] = -5;

            Console.Out.WriteLine(matrix[1, 2, 3]);

            int sum = matrix.Sum();
            Console.Out.WriteLine(sum);
        }
    }
}