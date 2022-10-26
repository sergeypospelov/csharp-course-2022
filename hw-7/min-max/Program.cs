using System;
using System.Text;

namespace min_max
{
    internal class Program
    {
        public static long[] MaxMin(long x)
        {
            long mn = x;
            long mx = x;


            string s = x.ToString();
            int n = s.Length;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (i == 0 && s[j] == '0')
                    {
                        continue;
                    }

                    var candidateStr = s.ToCharArray();
                    candidateStr[i] = s[j];
                    candidateStr[j] = s[i];
                    var candidate = long.Parse(new String(candidateStr));

                    mn = Math.Min(mn, candidate);
                    mx = Math.Max(mx, candidate);
                }
            }

            return new long[] { mx, mn };
        }

        public static void Main(string[] args)
        {
            var examples = new[]
            {
                12340,
                98761,
                9000,
                11321
            };

            foreach (var example in examples)
            {
                var ans = MaxMin(example);
                Console.Out.WriteLine($"{example} -> {string.Join(", ", ans)}");
            }
        }
    }
}