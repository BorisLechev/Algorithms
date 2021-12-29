using System;

namespace _07._PascalsTriangle
{
    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinom(rows, cols));
        }

        private static int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || row == col)
            {
                return 1;
            }

            return GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
        }
    }
}
