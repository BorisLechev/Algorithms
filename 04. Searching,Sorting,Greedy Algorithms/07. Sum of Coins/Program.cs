using System;
using System.Linq;
using System.Text;

namespace _07._Sum_of_Coins
{
    public class Program
    {
        public static void Main()
        {
            var coins = Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            var target = int.Parse(Console.ReadLine());

            var sortedCoins = coins
                            .OrderByDescending(c => c)
                            .ToArray();

            FindSum(sortedCoins, target);
        }

        private static void FindSum(int[] sortedCoins, int target)
        {
            var coinsCount = 0;
            var coinsIndex = 0;

            StringBuilder sb = new StringBuilder();

            while (target > 0 && coinsIndex < sortedCoins.Length)
            {
                var currentCoin = sortedCoins[coinsIndex];

                var count = target / currentCoin;
                target -= count * currentCoin;

                if (count > 0)
                {
                    coinsCount += count;
                    sb.AppendLine($"{count} coin(s) with value {sortedCoins[coinsIndex]}");
                }

                coinsIndex++;
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {coinsCount}");
                Console.WriteLine(sb.ToString().TrimEnd());
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
