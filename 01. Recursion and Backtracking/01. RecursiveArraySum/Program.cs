using System;
using System.Linq;

namespace _01._RecursiveArraySum
{
    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int index = 0;

            Console.WriteLine(CalcSum(array, index));
        }

        private static int CalcSum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + CalcSum(array, index + 1);
        }
    }
}
