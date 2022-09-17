using System;
using System.Collections.Generic;

namespace Immutable
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var list = new ImmutableList<int>(new List<int> { 1, 2, 3 });

            Console.Out.WriteLine("Old list:");
            foreach (var i in list)
            {
                Console.Out.Write($"{i} ");
            }
            Console.Out.WriteLine();

            var newList = list.Add(1).Add(2).Remove(3);

            Console.Out.WriteLine("New list:");
            foreach (var i in newList)
            {
                Console.Out.Write($"{i} ");
            }
            Console.Out.WriteLine();
        }
    }
}