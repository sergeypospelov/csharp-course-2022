using System;
using System.Collections.Generic;

namespace hamster
{
    public enum WoolColor
    {
        Red = 0,
        Green = 1,
        Blue = 2
    }

    public enum WoolType
    {
        Straight = 0,
        Wave = 1,
        Curly = 2
    }

    public class Hamster : IComparable<Hamster>
    {
        public readonly int Age;
        public readonly int Weight;
        public readonly int Height;
        public readonly WoolColor WoolColor;
        public readonly WoolType WoolType;

        public Hamster(int age, int weight, int height, WoolColor woolColor, WoolType woolType)
        {
            Age = age;
            Weight = weight;
            Height = height;
            WoolColor = woolColor;
            WoolType = woolType;
        }

        private static readonly Random Rnd = new Random();

        public static Hamster Random()
        {
            return new Hamster(
                Rnd.Next(0, 48),
                Rnd.Next(25, 65),
                Rnd.Next(4, 10),
                (WoolColor)Enum.GetValues(typeof(WoolColor)).GetValue(Rnd.Next(3)),
                (WoolType)Enum.GetValues(typeof(WoolType)).GetValue(Rnd.Next(3))
            );
        }

        public int CompareTo(Hamster y)
        {
            if (ReferenceEquals(this, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            var ageComparison = Age.CompareTo(y.Age);
            if (ageComparison != 0) return ageComparison;
            var weightComparison = Weight.CompareTo(y.Weight);
            if (weightComparison != 0) return weightComparison;
            var heightComparison = Height.CompareTo(y.Height);
            if (heightComparison != 0) return heightComparison;
            var woolColorComparison = WoolColor.CompareTo(y.WoolColor);
            if (woolColorComparison != 0) return woolColorComparison;
            return WoolType.CompareTo(y.WoolType);
        }

        public override string ToString()
        {
            return
                $"Hamster[age={Age}, weight={Weight}, height={Height}, woolColor={WoolColor.ToString()}, woolType={WoolType.ToString()}]";
        }
    }
}