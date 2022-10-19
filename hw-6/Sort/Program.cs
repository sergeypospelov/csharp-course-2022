using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    internal class Program
    {
        readonly struct Person
        {
            public string Name { get; }
            public int Age { get; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
            }

            public class ComparerByName : IComparer<Person>
            {
                public int Compare(Person x, Person y)
                {
                    if (x.Name.Length != y.Name.Length)
                    {
                        return x.Name.Length.CompareTo(y.Name.Length);
                    }

                    return char.ToLower(x.Name.First()).CompareTo(char.ToLower(y.Name.First()));
                }
            }

            public class ComparerByAge : IComparer<Person>
            {
                public int Compare(Person x, Person y)
                {
                    return x.Age.CompareTo(y.Age);
                }
            }
            
        }

        public static void Main(string[] args)
        {
            var example = new[]
            {
                new Person("Sergey", 21),
                new Person("Dmitry", 30),
                new Person("Andrey", 46),
                new Person("Olga", 13),
                new Person("Vova", 6),
            };

            Console.Out.WriteLine("By name:");
            Array.Sort(example, new Person.ComparerByName());
            foreach (var person in example)
            {
                Console.Out.WriteLine(person);
            }
            
            Console.Out.WriteLine("\nBy age:");
            Array.Sort(example, new Person.ComparerByAge());
            foreach (var person in example)
            {
                Console.Out.WriteLine(person);
            }
        }
    }
}