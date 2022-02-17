using System;
using System.Collections.Generic;

namespace _04._Salaries_with_Memoization
{
    public class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;

        public static void Main()
        {
            var numberOfEmployees = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfEmployees);
            visited = new Dictionary<int, int>();

            var totalSalary = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                totalSalary += GetSalaryDFS(node);
            }

            Console.WriteLine(totalSalary);
        }

        // node
        // regular employee - salary (1)
        // manager - salary = sum of children salary
        private static int GetSalaryDFS(int node)
        {
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            var children = graph[node];

            if (children.Count == 0)
            {
                return 1;
            }

            var salary = 0;

            foreach (var child in children)
            {
                salary += GetSalaryDFS(child);
            }

            visited[node] = salary;

            return salary;
        }

        private static List<int>[] ReadGraph(int numberOfEmployees)
        {
            var result = new List<int>[numberOfEmployees];

            for (int node = 0; node < numberOfEmployees; node++)
            {
                var children = new List<int>();
                var sequence = Console.ReadLine();

                for (int child = 0; child < sequence.Length; child++)
                {
                    if (sequence[child] == 'Y')
                    {
                        children.Add(child);
                    }
                }

                result[node] = children;
            }

            return result;
        }
    }
}
