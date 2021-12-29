using System;
using System.Linq;

namespace _01._PermutationsWithoutRepetitions
{
    public class Program
    {
        private static string[] inputElements;
        private static string[] permutations;
        private static bool[] usedElements;

        public static void Main()
        {
            inputElements = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

            permutations = new string[inputElements.Length];
            usedElements = new bool[inputElements.Length];

            Permute(0);
        }

        private static void Permute(int permutationsIndex)
        {
            if (permutationsIndex >= inputElements.Length)
            {
                Console.WriteLine(String.Join(" ", permutations));
                return;
            }

            for (int elementIndex = 0; elementIndex < inputElements.Length; elementIndex++)
            {
                if (usedElements[elementIndex] == false)
                {
                    usedElements[elementIndex] = true;
                    permutations[permutationsIndex] = inputElements[elementIndex];

                    Permute(permutationsIndex + 1);

                    // Backtracking
                    usedElements[elementIndex] = false;
                }
            }
        }
    }
}
