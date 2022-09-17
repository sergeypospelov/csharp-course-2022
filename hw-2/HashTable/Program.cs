using System;

namespace HashTable
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var hashtable = new HashTable<int, string>(2);

            while (true)
            {
                var cmd = Console.ReadLine()?.Split(' ');
                if (cmd == null)
                {
                    break;
                }

                switch (cmd[0].ToLower())
                {
                    case "add":
                        hashtable.Add(int.Parse(cmd[1]), cmd[2]);
                        break;
                    case "contains":
                        var exists = hashtable.ContainsKey(int.Parse(cmd[1]));
                        Console.Out.WriteLine($"{exists}");
                        break;
                    case "remove":
                        hashtable.Remove(int.Parse(cmd[1]));
                        break;
                    case "get":
                        var res = hashtable.Get(int.Parse(cmd[1]));
                        Console.Out.WriteLine(res);
                        break;
                    default:
                        Console.Out.WriteLine("unknown command");
                        break;
                }
                Console.Out.WriteLine($"Size = {hashtable.Size()}");
            }
        }
    }
}