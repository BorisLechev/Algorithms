using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SchoolTeams
{
    public class Program
    {
        public static void Main()
        {
            var girls = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var girlsCombinations = new string[3];
            var girlsCombinationsList = new List<string[]>();

            GenerateCombinations(0, 0, girls, girlsCombinations, girlsCombinationsList);

            var boys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var boysCombinations = new string[2];
            var boysCombinationsList = new List<string[]>();

            GenerateCombinations(0, 0, boys, boysCombinations, boysCombinationsList);

            PrintCombinations(girlsCombinationsList, boysCombinationsList);
        }

        private static void PrintCombinations(List<string[]> girlsCombinationsList, List<string[]> boysCombinationsList)
        {
            foreach (var girlsCombinations in girlsCombinationsList)
            {
                var girlsOutput = string.Join(", ", girlsCombinations);

                foreach (var boysCombinations in boysCombinationsList)
                {
                    var boysOutput = string.Join(", ", boysCombinations);

                    Console.WriteLine($"{girlsOutput}, {boysOutput}");
                }
            }
        }

        private static void GenerateCombinations(int combinationIndex, int namesStartIndex, string[] names, string[] combinations, List<string[]> combinationsList)
        {
            if (combinationIndex >= combinations.Length)
            {
                combinationsList.Add(combinations.ToArray()); // add ToArray() otherwise there is refference problem
                return;
            }

            for (int i = namesStartIndex; i < names.Length; i++)
            {
                combinations[combinationIndex] = names[i];

                GenerateCombinations(combinationIndex + 1, i + 1, names, combinations, combinationsList);
            }
        }
    }
}
