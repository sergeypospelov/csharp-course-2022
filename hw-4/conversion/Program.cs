using System;

namespace conversion
{
    internal class Program
    {
        public class Horse : IComparable<Horse>
        {
            public readonly int Age;
            public readonly bool HasHorseshoe;
            public readonly int Weight;

            public Horse(int age, bool hasHorseshoe, int weight)
            {
                Age = age;
                HasHorseshoe = hasHorseshoe;
                Weight = weight;
            }

            public int CompareTo(Horse other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                var ageComparison = Age.CompareTo(other.Age);
                if (ageComparison != 0) return ageComparison;
                var hasHorseshoeComparison = HasHorseshoe.CompareTo(other.HasHorseshoe);
                if (hasHorseshoeComparison != 0) return hasHorseshoeComparison;
                return Weight.CompareTo(other.Weight);
            }

            public override string ToString()
            {
                return $"{nameof(Age)}: {Age}, {nameof(HasHorseshoe)}: {HasHorseshoe}, {nameof(Weight)}: {Weight}";
            }

            public static explicit operator Car(Horse horse) => new Car(horse.Age, horse.HasHorseshoe, horse.Weight * 6);
        }

        public class Car
        {
            public readonly int Age;
            public readonly bool IsStudded;
            public readonly int Weight;

            public Car(int age, bool isStudded, int weight)
            {
                Age = age;
                IsStudded = isStudded;
                Weight = weight;
            }

            public override string ToString()
            {
                return $"{nameof(Age)}: {Age}, {nameof(IsStudded)}: {IsStudded}, {nameof(Weight)}: {Weight}";
            }

            public static explicit operator Horse(Car car) => new Horse(car.Age, car.IsStudded, car.Weight / 6);
        }


        public static void Main(string[] args)
        {
            var car = new Car(1, false, 1200);
            var horse = (Horse)car;

            Console.Out.WriteLine("Car:");
            Console.Out.WriteLine(car);

            Console.Out.WriteLine("Horse from car:");
            Console.Out.WriteLine(horse);

        }
    }
}