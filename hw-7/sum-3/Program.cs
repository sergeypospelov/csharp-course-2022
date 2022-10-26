using System;
using System.Collections.Generic;
using System.Linq;

namespace sum_3
{
    internal class Program
    {
        public static Tuple<int, int, int>[] SubsetsWithZeroSumOfSize3(int[] arr)
        {
            int n = arr.Length;
            var metValues = new HashSet<int>();
            var answers = new HashSet<Tuple<int, int, int>>();
            

            for (int i = 0; i + 1 < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int last = -arr[i] - arr[j];
                    if (metValues.Contains(last))
                    {
                        answers.Add(new Tuple<int, int, int>(last, arr[i], arr[j]));
                    }
                }

                metValues.Add(arr[i]);
            }

            return answers.OrderBy(x => x).ToArray();
        }

        public static void Main(string[] args)
        {
            var examples = new[]
            {
                new[] { 0, 1, -1, -1, 2 },
                new[] { 0, 0, 0, 5, -5 },
                new[] { 1, 2, 3 },
                new int[] { },
            };

            foreach (var example in examples)
            {
                var ans = SubsetsWithZeroSumOfSize3(example);
                Console.Out.WriteLine("Example: {" + string.Join(" ", example) + "}");
                Console.Out.WriteLine("Result: {" + string.Join(", ", (object[])ans) + "}");
                Console.Out.WriteLine();
            }
        }
    }
}