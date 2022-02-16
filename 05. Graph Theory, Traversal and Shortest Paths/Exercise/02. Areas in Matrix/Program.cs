using System;
using System.Collections.Generic;

namespace _02._Areas_in_Matrix
{
    public class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;

        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];
            var areas = new SortedDictionary<char, int>();

            var totalAreas = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }

                    var currentNode = matrix[row, col];

                    DFS(row, col, currentNode);
                    totalAreas++;

                    if (areas.ContainsKey(currentNode))
                    {
                        areas[currentNode]++;
                    }
                    else
                    {
                        areas[currentNode] = 1;
                    }
                }
            }

            Console.WriteLine($"Areas: {totalAreas}");

            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char currentNode)
        {
            if (IsInsideMatrix(row, col) == false ||
                IsVisited(row, col) ||
                IsChild(row, col, currentNode) == false)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row + 1, col, currentNode);
            DFS(row - 1, col, currentNode);
            DFS(row, col + 1, currentNode);
            DFS(row, col - 1, currentNode);
        }

        private static bool IsChild(int row, int col, char node) => matrix[row, col] == node;

        private static bool IsVisited(int row, int col) => visited[row, col];

        private static bool IsInsideMatrix(int row, int col)
        {
            return row >= 0 &&
                    row < matrix.GetLength(0) &&
                    col >= 0 &&
                    col < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var elements = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = elements[col];
                }
            }

            return result;
        }
    }
}
