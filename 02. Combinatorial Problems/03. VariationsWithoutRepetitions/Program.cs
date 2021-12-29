using System;
using System.Linq;

namespace _03._VariationsWithoutRepetitions
{
    public class Program
    {
        private static string[] inputElements;
        private static int slotsToFill;
        private static string[] variations;
        private static bool[] usedElements;

        public static void Main()
        {
            inputElements = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            slotsToFill = int.Parse(Console.ReadLine());

            variations = new string[slotsToFill];
            usedElements = new bool[inputElements.Length]; // track inputElements

            FindVariations(0);
        }

        private static void FindVariations(int variationIndex)
        {
            if (variationIndex >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int elementIndex = 0; elementIndex < inputElements.Length; elementIndex++)
            {
                if (usedElements[elementIndex] == false)
                {
                    usedElements[elementIndex] = true;
                    variations[variationIndex] = inputElements[elementIndex];

                    FindVariations(variationIndex + 1);

                    // Backtracking
                    usedElements[elementIndex] = false;
                }
            }
        }
    }
}
