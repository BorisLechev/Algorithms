using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._ConectedAreasInaMatrix
{
    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(rows, cols);
            var visited = new bool[rows, cols];

            var areas = new List<Area>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (IsWall(row, col, matrix) || IsCellVisited(row, col, visited))
                    {
                        continue;
                    }

                    var area = new Area() { Row = row, Col = col };
                    ExploreArea(row, col, matrix, visited, area);

                    if (area.Size > 0)
                    {
                        areas.Add(area);
                    }
                }
            }

            var sortedAreas = areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();

            PrintResult(sortedAreas);
        }

        private static void PrintResult(List<Area> areas)
        {
            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int rank = 1; rank <= areas.Count; rank++)
            {
                var currentArea = areas[rank - 1];

                Console.WriteLine($"Area #{rank} at ({currentArea.Row}, {currentArea.Col}), size: {currentArea.Size}");
            }
        }

        private static void ExploreArea(int row, int col, char[,] matrix, bool[,] visited, Area area)
        {
            if (IsOutside(row, col, matrix) ||
                IsWall(row, col, matrix) ||
                IsCellVisited(row, col, visited))
            {
                return;
            }

            area.Size++;
            visited[row, col] = true;

            ExploreArea(row + 1, col, matrix, visited, area);
            ExploreArea(row - 1, col, matrix, visited, area);
            ExploreArea(row, col + 1, matrix, visited, area);
            ExploreArea(row, col - 1, matrix, visited, area);
        }

        private static bool IsOutside(int row, int col, char[,] matrix)
        {
            return row < 0
                || row >= matrix.GetLength(0)
                || col < 0
                || col >= matrix.GetLength(1);
        }

        private static bool IsCellVisited(int row, int col, bool[,] visited) => visited[row, col];

        private static bool IsWall(int row, int col, char[,] matrix) => matrix[row, col] == '*';

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var columnElements = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = columnElements[col];
                }
            }

            return matrix;
        }
    }
}
