using System;
using System.Linq;

namespace _01._ReverseArrayWithoutRecursionTwo
{
    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Console.WriteLine(string.Join(" ", array.Reverse()));
        }
    }
}
