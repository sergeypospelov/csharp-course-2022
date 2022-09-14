using System;

namespace Stack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var stck = new Stack<int>();
            stck.Push(1);
            Console.Out.WriteLine($"{stck.MinValue()}");
            stck.Push(4);
            Console.Out.WriteLine($"{stck.MinValue()}");
            stck.Push(-2);
            Console.Out.WriteLine($"{stck.MinValue()}");
            stck.Pop();
            Console.Out.WriteLine($"{stck.MinValue()}");
            stck.Pop();
        }
    }
}