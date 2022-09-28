using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindromes
{
    internal class Program
    {
        internal readonly struct Result
        {
            public readonly long First;
            public readonly int Steps;

            public Result(long first, int steps)
            {
                First = first;
                Steps = steps;
            }
        }

        public static Result PalSeq(long palindrome)
        {
            var used = new HashSet<long>();
            
            var s = palindrome.ToString();
            var reversedS = new string(s.Reverse().ToArray());
            if (reversedS != s)
            {
                throw new ArgumentException($"{s} is not a palindrome!");
            }

            for (long begin = 1;; begin++)
            {
                if (used.Contains(begin))
                {
                    continue;
                }
                long cur = begin;
                int steps = 0;

                used.Add(cur);
                while (cur < palindrome)
                {
                    var reversedCurAsString = new string(cur.ToString().Reverse().ToArray());
                    var curReversed = long.Parse(reversedCurAsString);
                    cur += curReversed;
                    steps++;
                    used.Add(cur);
                }

                if (cur == palindrome)
                {
                    return new Result(begin, steps);
                }
            }
        }

        public static void Main(string[] args)
        {
            long[] palindromes = new long[]
            {
                4884,
                1,
                11,
                3113,
                8836886388,
                13377331,
            };
            foreach (var palindrome in palindromes)
            {
                var res = PalSeq(palindrome);
                Console.Out.WriteLine($"{palindrome} -> ({res.First}, {res.Steps})");
            }
        }
    }
}