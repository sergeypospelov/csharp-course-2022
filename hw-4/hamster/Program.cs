using System;
using System.Linq;

namespace hamster
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var hamsters = Enumerable.Repeat(0, 10).Select(_ => Hamster.Random()).ToList();

            Console.Out.WriteLine("Before:");
            foreach (var hamster in hamsters)
            {
                Console.Out.WriteLine($"{hamster}");
            }
            
            hamsters.Sort();
            
            Console.Out.WriteLine("After:");
            foreach (var hamster in hamsters)
            {
                Console.Out.WriteLine($"{hamster}");
            }
        }
    }
}