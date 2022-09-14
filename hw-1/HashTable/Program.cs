using System;
using System.Text;

namespace HashTable
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var weekDays = new HashTable<string, string>(3);

            weekDays.Add("Monday", "Понедельник");
            weekDays.Add("Tuesday", "Вторник");
            weekDays.Add("Wednesday", "Среда");
            weekDays.Add("Thursday", "Четверг");
            weekDays.Add("Friday", "Пятница");
            weekDays.Add("Saturday", "Суббота");
            weekDays.Add("Sunday", "Воскресенье");

            while (true)
            {
                var day = Console.ReadLine();
                var russianDay = weekDays.Get(day);

                Console.Out.WriteLine(russianDay != null
                    ? $"{day} in Russian is {russianDay}"
                    : $"I don't know {day}!"
                );
            }
        }
    }
}