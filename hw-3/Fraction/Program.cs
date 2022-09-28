using System;

namespace Fraction
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var examples = new string[]
            {
                "4/6",
                "10/11",
                "100/400",
                "8/4",
                "-10/-4",
                "15/-20"
            };

            foreach (var example in examples)
            {
                var simplified = Simplify(example);
                Console.Out.WriteLine($"{example} -> {simplified}");
            }
        }

        private static string Simplify(string s)
        {
            var splits = s.Split('/');
            if (splits.Length != 2)
            {
                throw new ArgumentException($"Can't parse fraction from {s}");
            }

            var dividend = int.Parse(splits[0]);
            var divisor = int.Parse(splits[1]);
            if (divisor == 0)
            {
                throw new ArgumentException("Divisor can't be null");
            }

            var gcd = Gcd(Math.Abs(dividend), Math.Abs(divisor));
            dividend /= gcd;
            divisor /= gcd;

            if (divisor < 0)
            {
                dividend *= -1;
                divisor *= -1;
            }
            
            return dividend + (divisor > 1 ? "/" + divisor : "");
        }

        private static int Gcd(int a, int b)
        {
            return b > 0 ? Gcd(b, a % b) : a;
        }
    }
}