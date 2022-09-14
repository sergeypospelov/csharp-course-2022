using System;

namespace Generator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var password = Generator.GeneratePassword();
            Console.Write(password);
        }
    }
}