using System;

namespace _07._RecursiveFibonacci
{
    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var fibonacci = GetFibonacci(number);

            Console.WriteLine(fibonacci);
        }

        private static int GetFibonacci(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return GetFibonacci(number - 1) + GetFibonacci(number - 2);
        }
    }
}
