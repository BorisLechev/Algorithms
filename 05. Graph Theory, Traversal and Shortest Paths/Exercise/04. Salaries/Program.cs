using System;
using System.Collections.Generic;

namespace _04._Salaries
{
    public class Program
    {
        private static List<int>[] graph;

        public static void Main()
        {
            var numberOfEmployees = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfEmployees);

            var totalSalaries = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                totalSalaries += GetSalaryDFS(node);
            }

            Console.WriteLine(totalSalaries);
        }

        private static int GetSalaryDFS(int node)
        {
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

            return salary;
        }

        private static List<int>[] ReadGraph(int numberOfEmployees)
        {
            var result = new List<int>[numberOfEmployees];

            for (int node = 0; node < numberOfEmployees; node++)
            {
                var children = new List<int>();
                var sequence = Console.ReadLine();

                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == 'Y')
                    {
                        children.Add(i);
                    }
                }

                result[node] = children;
            }

            return result;
        }
    }
}
