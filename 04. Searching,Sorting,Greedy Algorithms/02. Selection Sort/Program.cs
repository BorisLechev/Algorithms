using System;
using System.Linq;

namespace _02._Selection_Sort
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            SelectionSort(input);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var minIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                Swap(numbers, i, minIndex);
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
