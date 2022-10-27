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
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Where(c => !punctuationMarks.Contains(c)))
                .Select(s => string.Concat(s))
                .GroupBy(s => s.Length)
                .Where(group => group.Key > 0)
                .Select(grouping => grouping.ToList())
                .OrderBy(gr => -gr.Count);
            return result;
        }

        public static IEnumerable<String> Task4(string text, Dictionary<string, string> dict, int words)
        {
            return text
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => dict[word.ToLower()].ToUpper())
                .Chunk(words)
                .Select(line => string.Join(" ", line));
        }

        public static IEnumerable<String> Task5(string text, int symbols)
        {
            return text
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(new List<string>(), (prv, word) =>
                {
                    if (prv.Count > 0 && prv.Last().Length + word.Length + 1 <= symbols)
                    {
                        prv[^1] = prv.Last() + " " + word;
                    }
                    else
                    {
                        prv.Add(word);
                    }

                    return prv;
                });
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

            var example4 = "This dog eats too much vegetables after lunch";
            var dictionary = new Dictionary<String, String>();
            dictionary.Add("this", "эта");
            dictionary.Add("dog", "собака");
            dictionary.Add("eats", "ест");
            dictionary.Add("too", "слишком");
            dictionary.Add("much", "много");
            dictionary.Add("vegetables", "овощей");
            dictionary.Add("after", "после");
            dictionary.Add("lunch", "обеда");
            var res4 = Task4(example4, dictionary, 3);
            foreach (var line in res4)
            {
                Console.Out.WriteLine(line);
            }

            var examples5 = new[]
            {
                new Tuple<string, int>("она продает морские раковины у моря", 16),
                new Tuple<string, int>("мышь прыгнула через сыр", 8),
                new Tuple<string, int>("волшебная пыль покрыла воздух", 15),
                new Tuple<string, int>("a b  c d e", 2)
            };
            foreach (var (str, cnt) in examples5)
            {
                var res = Task5(str, cnt);
                Console.Out.WriteLine(str + ":");
                foreach (var el in res)
                {
                    Console.Out.WriteLine(string.Join(" ", el));
                }
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