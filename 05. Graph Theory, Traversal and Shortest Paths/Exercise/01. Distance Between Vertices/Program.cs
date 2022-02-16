using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;

        public static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var pairs = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodes);

            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine()
                            .Split('-', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                var startNode = pair[0];
                var destinationNode = pair[1];

                var steps = GetShortestPathBFS(startNode, destinationNode);

                Console.WriteLine($"{{{startNode}, {destinationNode}}} -> {steps}");
            }
        }

        private static int GetShortestPathBFS(int startNode, int destinationNode)
        {
            var queue = new Queue<int>();

            queue.Enqueue(startNode);

            var steps = new Dictionary<int, int>()
            {
                {startNode, 0 },
            };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destinationNode)
                {
                    return steps[node];
                }

                foreach (var child in graph[node])
                {
                    if (steps.ContainsKey(child))
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                    steps[child] = steps[node] + 1;
                }
            }

            return -1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int nodes)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                var parts = Console.ReadLine()
                            .Split(':', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                var node = int.Parse(parts[0]);

                if (parts.Length == 1)
                {
                    result[node] = new List<int>();
                }
                else
                {
                    var children = parts[1]
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

                    result[node] = children;
                }
            }

            return result;
        }
    }
}
