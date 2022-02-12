using System;
using System.Linq;

namespace _05._QuickSort
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            QuickSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            var pivot = startIndex;
            var left = startIndex + 1;
            var right = endIndex;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    left += 1;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right -= 1;
                }
            }

            Swap(numbers, pivot, right);

            var isLeftSubarraySmallerSize = right - 1 - startIndex < endIndex - (right + 1);

            if (isLeftSubarraySmallerSize)
            {
                QuickSort(numbers, startIndex, right - 1);
                QuickSort(numbers, right + 1, endIndex);
            }
            else
            {
                QuickSort(numbers, right + 1, endIndex);
                QuickSort(numbers, startIndex, right - 1);
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
