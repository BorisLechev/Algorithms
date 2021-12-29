using System;
using System.Linq;

namespace _05._CombinationsWithoutRepetition
{
    public class Program
    {
        private static string[] inputElements;
        private static int slotsToFill;
        private static string[] combinations;

        public static void Main()
        {
            inputElements = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            slotsToFill = int.Parse(Console.ReadLine());

            combinations = new string[slotsToFill];

            FindCombinations(0, 0);
        }

        private static void FindCombinations(int combinationIndex, int inputElementsStartIndex)
        {
            if (combinationIndex >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int elementIndex = inputElementsStartIndex; elementIndex < inputElements.Length; elementIndex++)
            {
                combinations[combinationIndex] = inputElements[elementIndex];

                FindCombinations(combinationIndex + 1, elementIndex + 1);
            }
        }
    }
}
