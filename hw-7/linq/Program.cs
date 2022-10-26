using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq
{
    internal class Program
    {
        public static String Task1(ICollection<ClassWithName> elements, string delimeter)
        {
            if (elements.Count <= 3)
            {
                return "";
            }

            return elements.Skip(3).Select(x => x.Name).Aggregate((s, s1) => s + delimeter + s1);
        }

        public static IEnumerable<ClassWithName> Task2(IEnumerable<ClassWithName> elements)
        {
            return elements.Where((el, i) => el.Name.Length > i);
        }

        public static IEnumerable<IEnumerable<string>> Task3(string sentence, IEnumerable<char> punctuationMarks)
        {
            var result = sentence
                .Split(' ')
                .Select(s => s.Where(c => !punctuationMarks.Contains(c)))
                .Select(s => string.Concat(s))
                .GroupBy(s => s.Length)
                .Where(group => group.Key > 0)
                .Select(grouping => grouping.ToList())
                .OrderBy(gr => -gr.Count());
            return result;
        }

        public static void Main(string[] args)
        {
            var res1 = Task1(new List<ClassWithName>(new[]
                {
                    new ClassWithName("Name1"),
                    new ClassWithName("Name2"),
                    new ClassWithName("Name3"),
                    new ClassWithName("Name4"),
                    new ClassWithName("Name5"),
                    new ClassWithName("Name6")
                }), ", "
            );
            Console.Out.WriteLine(res1);

            var res2 = Task2(new List<ClassWithName>(new[]
                {
                    new ClassWithName("abcde"),
                    new ClassWithName("a"),
                    new ClassWithName("abc"),
                    new ClassWithName("abcde"),
                    new ClassWithName("a"),
                    new ClassWithName("abcd")
                })
            );
            Console.Out.WriteLine(String.Join(" ", res2));

            Console.OutputEncoding = Encoding.UTF8;
            var example3 = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
            var res3 = Task3(example3, ",-:!?'\".");
            foreach (var group in res3)
            {
                var groupAsList = group.ToList();
                Console.Out.WriteLine("Length: " + groupAsList.First().Length + " Size: " + groupAsList.Count());
                Console.Out.WriteLine(string.Join("\n", groupAsList));
            }
        }
    }

    internal class ClassWithName
    {
        public string Name { get; }

        public ClassWithName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}