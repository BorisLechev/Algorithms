using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cinema
{
    public class Program
    {
        private static List<string> names;
        private static string[] seats;
        private static bool[] lockedSeats;

        public static void Main()
        {
            names = Console.ReadLine()
                    .Split(", ")
                    .ToList();

            seats = new string[names.Count];
            lockedSeats = new bool[names.Count];

            string inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "generate")
            {
                var parts = inputLine.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                seats[position] = name;
                lockedSeats[position] = true;
                names.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                PrintOutput();
                return;
            }

            // reach the bottom
            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintOutput()
        {
            var nameIndex = 0;

            for (int i = 0; i < seats.Length; i++)
            {
                if (lockedSeats[i] == false)
                {
                    seats[i] = names[nameIndex];
                    nameIndex += 1;
                }
            }

            Console.WriteLine(string.Join(" ", seats));
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            var temp = names[firstIndex];
            names[firstIndex] = names[secondIndex];
            names[secondIndex] = temp;
        }
    }
}
