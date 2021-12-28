using System;
using System.Collections.Generic;

namespace _06._8QuennsPuzzle
{
    public class Program
    {
        private static readonly int chessboardSize = 8;
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            var chessboard = new bool[chessboardSize, chessboardSize];

            PlaceQueens(chessboard, 0);
        }

        private static void PlaceQueens(bool[,] chessboard, int row)
        {
            if (row == chessboard.GetLength(0))
            {
                PrintChessboard(chessboard);
                return;
            }

            for (int col = 0; col < chessboard.GetLength(1); col++)
            {
                if (IsAttackedPositionByQueen(row, col) == false)
                {
                    chessboard[row, col] = true;
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col);
                    attackedRightDiagonals.Add(row + col);

                    PlaceQueens(chessboard, row + 1);

                    // Backtracking - generating solution for other position of the Queen
                    chessboard[row, col] = false;
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col);
                    attackedRightDiagonals.Remove(row + col);
                }
            }
        }

        private static bool IsAttackedPositionByQueen(int row, int col)
        {
            return attackedRows.Contains(row) ||
                attackedCols.Contains(col) ||
                attackedLeftDiagonals.Contains(row - col) ||
                attackedRightDiagonals.Contains(row + col);
        }

        private static void PrintChessboard(bool[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
