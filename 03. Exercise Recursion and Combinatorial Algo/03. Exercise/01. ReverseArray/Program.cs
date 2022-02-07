using System;
using System.Linq;

namespace _01._ReverseArray
{
    public class Program
    {
        private static string[] array;

        public static void Main()
        {
            array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            ReverseArray(0);

            Console.WriteLine(string.Join(" ", array));
        }

        private static void ReverseArray(int startIndex)
        {
            if (startIndex >= array.Length / 2)
            {
                return;
            }

            var secondIndex = array.Length - 1 - startIndex;
            SwapElements(startIndex, secondIndex);

            // Reach the "bottom"
            ReverseArray(startIndex + 1);
        }

        private static void SwapElements(int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];

            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
