using System;
using System.Linq;

namespace _01._Binary_Search
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var element = int.Parse(Console.ReadLine());

            var resultIndex = BinarySearch(input, element);

            Console.WriteLine(resultIndex);
        }

        private static int BinarySearch(int[] numbers, int targetNumber)
        {
            var startIndex = 0;
            var endIndex = numbers.Length - 1;

            while (startIndex <= endIndex)
            {
                var middleIndex = (startIndex + endIndex) / 2;

                if (numbers[middleIndex] == targetNumber)
                {
                    return middleIndex;
                }
                else if (numbers[middleIndex] < targetNumber)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex - 1;
                }
            }

            return -1;
        }
    }
}
