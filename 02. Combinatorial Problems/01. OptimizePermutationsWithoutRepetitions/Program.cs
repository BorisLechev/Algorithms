using System;
using System.Linq;

namespace _01._OptimizePermutationsWithoutRepetitions
{
    public class Program
    {
        private static string[] inputElements;

        public static void Main()
        {
            inputElements = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
            Permute(0);
        }

        private static void Permute(int permutationsIndex)
        {
            if (permutationsIndex >= inputElements.Length)
            {
                Console.WriteLine(String.Join(" ", inputElements));
                return;
            }

            // Generate first permutation and reach the "bottom" - A B C
            Permute(permutationsIndex + 1);

            for (int elementIndex = permutationsIndex + 1; elementIndex < inputElements.Length; elementIndex++)
            {
                SwapElements(permutationsIndex, elementIndex);
                Permute(permutationsIndex + 1);
                SwapElements(permutationsIndex, elementIndex);
            }
        }

        private static void SwapElements(int firstIndex, int secondIndex)
        {
            var temp = inputElements[firstIndex];
            inputElements[firstIndex] = inputElements[secondIndex];
            inputElements[secondIndex] = temp;
        }
    }
}
