using System;

namespace _03._Generating01Vectors
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var vector = new int[n];

            Generate01(vector, 0);
        }

        private static void Generate01(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(String.Join("", vector));
                return;
            }

            for (int number = 0; number <= 1; number++)
            {
                vector[index] = number;

                Generate01(vector, index + 1);
            }
        }
    }
}
