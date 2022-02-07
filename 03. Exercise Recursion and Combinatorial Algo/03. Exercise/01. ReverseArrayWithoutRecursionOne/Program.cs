using System;
using System.Linq;

namespace _01._ReverseArrayWithoutRecursionOne
{
    public class Program
    {
        private static string[] array;

        public static void Main()
        {
            array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int left = 0; left < array.Length / 2; left++)
            {
                var right = array.Length - 1 - left;

                SwapElements(left, right);
            }

            Console.WriteLine(String.Join(" ", array));
        }

        private static void SwapElements(int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];

            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
