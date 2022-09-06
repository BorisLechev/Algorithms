namespace _07._1.SumOfCoins
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                        .Split(", ", StringSplitOptions.None)
                        .Select(int.Parse)
                        .OrderByDescending(c => c)
                        .ToArray();

            var coins = new Queue<int>(input);

            var target = int.Parse(Console.ReadLine());
            var usedCoins = new Dictionary<int, int>();
            var totalCoins = 0;

            while (target > 0 && coins.Count > 0)
            {
                var currentCoin = coins.Dequeue();
                var count = target / currentCoin;

                if (count == 0)
                {
                    continue;
                }

                usedCoins[currentCoin] = count;
                totalCoins += count;

                target %= currentCoin;
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoins}");

                foreach (var usedCoin in usedCoins)
                {
                    Console.WriteLine($"{usedCoin.Value} coin(s) with value {usedCoin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}