using System;

namespace interfaces
{
    abstract class Animal
    {
        public abstract string SayHello();
    }

    interface IFelidae
    {
        string SayHello();
    }

    interface ICanidae
    { 
        string SayHello();
    }

    class CatDog : Animal, IFelidae, ICanidae
    {
        public override string SayHello()
        {
            return "meow woof";
        }

        string IFelidae.SayHello()
        {
            return "meow";
        }

        string ICanidae.SayHello()
        {
            return "woof";
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
            var catDog = new CatDog();

            Console.Out.WriteLine(catDog.SayHello());
            Console.Out.WriteLine(((IFelidae)catDog).SayHello());
            Console.Out.WriteLine(((ICanidae)catDog).SayHello());
        }
    }
}