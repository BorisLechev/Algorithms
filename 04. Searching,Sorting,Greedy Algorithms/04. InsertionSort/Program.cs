using System;
using System.Linq;

namespace _04._InsertionSort
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            InsertionSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var j = i;

                while (j > 0 && numbers[j - 1] > numbers[j])
                {
                    Swap(numbers, j - 1, j);
                    j -= 1;
                }
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
