using System;

namespace _04._CombinationsWithoutRepetition
{
    public class Program
    {
        private static int numberOfElements;

        private static int slotsToFill;

        private static int[] combinations;

        public static void Main()
        {
            numberOfElements = int.Parse(Console.ReadLine());
            slotsToFill = int.Parse(Console.ReadLine());

            combinations = new int[slotsToFill];

            FindCombinations(0, 1);
        }

        private static void FindCombinations(int combinationIndex, int startIndex)
        {
            if (combinationIndex >= slotsToFill)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int number = startIndex; number <= numberOfElements; number++)
            {
                combinations[combinationIndex] = number;

                FindCombinations(combinationIndex + 1, number + 1);
            }
        }
    }
}
