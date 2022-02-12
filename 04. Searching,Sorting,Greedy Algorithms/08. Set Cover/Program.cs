using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Set_Cover
{
    public class Program
    {
        public static void Main()
        {
            var universe = Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            var numberOfSets = int.Parse(Console.ReadLine());
            var sets = new List<int[]>();

            for (int i = 0; i < numberOfSets; i++)
            {
                var set = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }

            List<int[]> selectedSets = TakeSets(universe, sets);

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }

        private static List<int[]> TakeSets(int[] universe, List<int[]> sets)
        {
            var selectedSets = new List<int[]>();

            while (universe.Length > 0)
            {
                var currentSet = sets
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(currentSet);
                sets.Remove(currentSet);
                universe = universe
                    .Where(e => !currentSet.Contains(e))
                    .ToArray();
            }

            return selectedSets;
        }
    }
}
