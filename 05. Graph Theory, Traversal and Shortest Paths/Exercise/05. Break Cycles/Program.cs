using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Break_Cycles
{
    public class Edge
    {
        public Edge(string first, string second)
        {
            this.First = first;
            this.Second = second;
        }

        public string First { get; }

        public string Second { get; }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }

        public string ToStringReversed()
        {
            return $"{this.Second} - {this.First}";
        }
    }

    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        public static void Main()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            ProcessInput(numberOfNodes);

            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();
            
            var removedEdges = new List<Edge>();
            var reversedEdges = new HashSet<string>();

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                graph[first].Remove(second); // 1 - 2
                graph[second].Remove(first); // 2 - 1 (reversed)

                if (HasPathBFS(first, second))
                {
                    if (reversedEdges.Contains(edge.ToString()))
                    {
                        continue;
                    }

                    removedEdges.Add(edge);
                    reversedEdges.Add(edge.ToStringReversed());
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static bool HasPathBFS(string source, string destination)
        {
            var queue = new Queue<string>();

            queue.Enqueue(source);

            var visited = new HashSet<string> { source };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                var children = graph[node];

                foreach (var child in children)
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                    visited.Add(child);
                }
            }

            return false;
        }

        private static void ProcessInput(int numberOfNodes)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                var parts = Console.ReadLine()
                            .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                var node = parts[0];
                var children = parts[1].Split().ToArray();

                if (graph.ContainsKey(node) == false)
                {
                    graph[node] = new List<string>();
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edge(node, child));
                }
            }
        }
    }
}
