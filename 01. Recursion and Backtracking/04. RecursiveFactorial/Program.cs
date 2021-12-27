using System;

namespace _04._RecursiveFactorial
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFactorial(n));
        }

        private static int CalculateFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * CalculateFactorial(n - 1);
        }
    }
}
