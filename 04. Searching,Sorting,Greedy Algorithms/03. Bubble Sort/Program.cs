using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            BubbleSort(input);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void BubbleSort(int[] numbers)
        {
            var isSorted = false;
            var sortedElementsCount = 0;

            while (isSorted == false)
            {
                isSorted = true;

                for (int i = 1; i < numbers.Length - sortedElementsCount; i++)
                {
                    if (numbers[i - 1] > numbers[i])
                    {
                        Swap(numbers, i - 1, i);
                        isSorted = false;
                    }
                }

                sortedElementsCount += 1;
            }
        }

        private static void Swap(int[] numbers, int firstIndex, int secondIndex)
        {
            var temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }
    }
}
