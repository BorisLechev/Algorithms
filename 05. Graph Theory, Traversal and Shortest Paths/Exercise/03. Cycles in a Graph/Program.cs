using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cycles_in_a_Graph
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        public static void Main()
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
                return;
            }

            Console.WriteLine("Acyclic: Yes");
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                var parts = line
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var node = parts[0];
                var child = parts[1];

                if (result.ContainsKey(node) == false)
                {
                    result[node] = new List<string>();
                }
                if (result.ContainsKey(child) == false)
                {
                    result[child] = new List<string>();
                }

                result[node].Add(child);
            }

            return result;
        }
    }
}
