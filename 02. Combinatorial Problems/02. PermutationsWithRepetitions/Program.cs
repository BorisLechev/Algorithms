using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._PermutationsWithRepetitions
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
                Console.WriteLine(string.Join(" ", inputElements));
                return;
            }

            Permute(permutationsIndex + 1);

            var permutations = new HashSet<string>() { inputElements[permutationsIndex] };

            for (int elementIndex = permutationsIndex + 1; elementIndex < inputElements.Length; elementIndex++)
            {
                if (permutations.Contains(inputElements[elementIndex]) == false)
                {
                    SwapElements(permutationsIndex, elementIndex);
                    Permute(permutationsIndex + 1);
                    SwapElements(permutationsIndex, elementIndex);

                    permutations.Add(inputElements[elementIndex]);
                }
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
