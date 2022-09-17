using System;
using System.Linq;

namespace Rolls
{
    internal static class Program
    {
        public static ulong DiceRoll(uint cubes, uint value)
        {
            if (value > cubes * 6)
            {
                return 0;
            }
            
            var cnt = new ulong[cubes * 6 + 1];
            cnt[0] = 1;
            
            for (int c = 1; c <= cubes; c++)
            {
                for (int val = c * 6; val >= 0; val--)
                {
                    cnt[val] = 0;
                    for (int prv = val - 1; prv >= Math.Max(0, val - 6); prv--)
                    {
                        cnt[val] += cnt[prv];
                    }
                }
            }

            return cnt[value];
        }
        
        public static void Main(string[] args)
        {
            var input = Console.In.ReadLine()!.Split(' ').Select(uint.Parse).ToArray();
            uint cubes = input[0];
            uint value = input[1];
            var res = DiceRoll(cubes, value);
            Console.Out.WriteLine(res);
        }
    }
}