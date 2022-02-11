using System;
using System.Linq;

namespace _06._MergeSort
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            var result = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }

            var leftPart = numbers.Take(numbers.Length / 2).ToArray();
            var rightPart = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(leftPart), MergeSort(rightPart));
        }

        private static int[] Merge(int[] leftPart, int[] rightPart)
        {
            var merged = new int[leftPart.Length + rightPart.Length];

            var leftIndex = 0;
            var rightIndex = 0;
            var mergedIndex = 0;

            while (leftIndex < leftPart.Length && rightIndex < rightPart.Length)
            {
                if (leftPart[leftIndex] < rightPart[rightIndex])
                {
                    merged[mergedIndex] = leftPart[leftIndex];
                    leftIndex++;
                }
                else
                {
                    merged[mergedIndex] = rightPart[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }

            for (int i = leftIndex; i < leftPart.Length; i++)
            {
                merged[mergedIndex] = leftPart[i];
                mergedIndex++;
            }

            for (int i = rightIndex; i < rightPart.Length; i++)
            {
                merged[mergedIndex] = rightPart[i];
                mergedIndex++;
            }

            return merged;
        }
    }
}
