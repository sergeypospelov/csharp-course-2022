using System;
using System.Linq;

namespace Rain
{
    internal static class Program
    {
        private static int[] CalcPrefixMaximums(int[] arr)
        {
            var n = arr.Length;
            var res = new int[n + 1];
            res[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                res[i] = Math.Max(res[i - 1], arr[i - 1]);
            }

            return res;
        }

        public static void Main(string[] args)
        {
            var values = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            var n = values.Length;

            var forwardMaximums = CalcPrefixMaximums(values);
            var backwardMaximums = CalcPrefixMaximums(values.Reverse().ToArray()).Reverse().ToArray();

            var sum = 0L;

            for (int i = 0; i < n; i++)
            {
                var min = Math.Min(forwardMaximums[i], backwardMaximums[i + 1]);
                sum += Math.Max(0, min - values[i]);
            }
            Console.Out.WriteLine(sum);
        }
    }
}