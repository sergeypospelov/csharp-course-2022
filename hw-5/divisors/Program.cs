using System;
using System.Collections.Generic;

namespace divisors
{
    readonly struct Factor
    {
        public readonly long Value;
        public readonly int Power;

        public Factor(long value, int power)
        {
            Value = value;
            Power = power;
        }

        public override string ToString()
        {
            return $"{Value}" + (Power > 1 ? $"^{Power}" : "");
        }
    }
    
    internal class Program
    {
        public static IEnumerable<Factor> ExpressFactors(long value)
        {
            var factors = new List<Factor>();
            
            for (var i = 2; i * i <= value; i++)
            {
                var power = 0;
                while (value % i == 0)
                {
                    value /= i;
                    power++;
                }

                if (power != 0)
                {
                    factors.Add(new Factor(i, power));
                }
            }

            if (value != 1)
            {
                factors.Add(new Factor(value, 1));
            }

            return factors;
        }
        
        public static void Main(string[] args)
        {
            var examples = new[]
            {
                2,
                4,
                10,
                60,
                239,
                1000,
                1791791791,
                753208157208154,
            };

            foreach (var example in examples)
            {
                var factors = ExpressFactors(example);
                var result = String.Join(" x ", factors);
                Console.Out.WriteLine($"{example} = {result}");
            }
        }
    }
}