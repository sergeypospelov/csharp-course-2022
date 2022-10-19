using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lake
{
    class Lake : IEnumerable<int>
    {
        private List<int> _stonesUp;
        private List<int> _stonesDown;

        public Lake(int[] stones)
        {
            var grouping = stones
                .Select((it, idx) => new KeyValuePair<int, int>(idx, it))
                .GroupBy(pair => (pair.Key % 2 + 2) % 2)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(pair => pair.Value).ToList()
                );

            _stonesUp = grouping[0];
            _stonesDown = grouping[1];
            _stonesDown.Reverse();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _stonesUp.Concat(_stonesDown).GetEnumerator();
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
            var examples = new[]
            {
                new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
                new[] { 13, 23, 1, -8, 4, 9 }
            };

            foreach (var example in examples)
            {
                var lake = new Lake(example);

                foreach (var stone in lake)
                {
                    Console.Out.Write(stone + " ");
                }

                Console.Out.WriteLine();
            }
        }
    }
}