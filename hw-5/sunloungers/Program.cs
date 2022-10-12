using System;
using System.Linq;

namespace sunloungers
{
    internal class Program
    {
        public static int SunLoungers(string s)
        {
            var splits = s
                .Split(new[] { '1' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(it => it.Length)
                .ToList();

            if (splits.Count == 0)
            {
                return 0;
            }

            var sum = 0;

            for (var i = 1; i < splits.Count - 1; i++)
            {
                sum += splits[i] / 2;
            }

            var extra1 = 0;
            if (s[0] == '0')
            {
                extra1++;
            }
            else
            {
                extra1--;
            }

            if (splits[0] == s.Length)
            {
                extra1++;
            }
            else
            {
                extra1--;

                if (splits.Count > 1)
                {

                    var extra2 = -1;
                    if (s.Last() == '0')
                    {
                        extra2++;
                    }
                    else
                    {
                        extra2--;
                    }

                    sum += (splits[1] + extra2 / 2) / 2;
                }
            }
            sum += (splits[0] + extra1 / 2) / 2;

            
            // [) -> sz / 2
            // (] -> sz / 2
            // [] -> (sz + 1) / 2;
            // () -> (sz - 1) / 2

            return sum;
        }

        public static void Main(string[] args)
        {
            var examples = new string[]
            {
                "10001",
                "00101",
                "0",
                "000",
                "00",
                "1",
                "11",
                "10101",
                "1001001",
                "100010001"
            };

            foreach (var example in examples)
            {
                var result = SunLoungers(example);

                Console.Out.WriteLine($"{example} -> {result}");
            }
        }
    }
}