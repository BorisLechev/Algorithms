using System;
using System.Linq;

namespace _04._VariationsWithRepetition
{
    public class Program
    {
        private static string[] inputElements;
        private static int slotsToFill;
        private static string[] variations;

        public static void Main()
        {
            inputElements = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            slotsToFill = int.Parse(Console.ReadLine());

            variations = new string[slotsToFill];

            FindVariations(0);
        }

        private static void FindVariations(int variationIndex)
        {
            if (variationIndex >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int elementIndex = 0; elementIndex < inputElements.Length; elementIndex++)
            {
                variations[variationIndex] = inputElements[elementIndex];

                FindVariations(variationIndex + 1);
            }
        }
    }
}
