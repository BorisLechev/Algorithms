using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shortest_Path
{
    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parents;

        public static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodes, edges);
            visited = new bool[graph.Length];
            parents = new int[graph.Length];
            Array.Fill(parents, -1);

            var startNode = int.Parse(Console.ReadLine());
            var destinationNode = int.Parse(Console.ReadLine());

            BFS(startNode, destinationNode);
        }

        private static void BFS(int startNode, int destinationNode)
        {
            if (visited[startNode])
            {
                return;
            }

            var queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destinationNode)
                {
                    var path = ReconstructPath(destinationNode);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));

                    return;
                }

                foreach (var child in graph[node])
                {
                    if (visited[child] == false)
                    {
                        queue.Enqueue(child);
                        parents[child] = node;
                        visited[child] = true;
                    }
                }
            }
        }

        // if we use List we should reverse the path.
        private static Stack<int> ReconstructPath(int destinationNode)
        {
            var path = new Stack<int>();

            var index = destinationNode;

            while (index != -1)
            {
                path.Push(index);
                index = parents[index];
            }

            return path;
        }

        private static List<int>[] ReadGraph(int nodes, int edges)
        {
            var result = new List<int>[nodes + 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                var from = edge[0];
                var to = edge[1];

                if (result[from] == null)
                {
                    result[from] = new List<int>();
                }

                result[from].Add(to);
            }

            return result;
        }
    }
}
