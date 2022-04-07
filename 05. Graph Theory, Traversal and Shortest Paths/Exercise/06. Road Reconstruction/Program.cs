using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Road_Reconstruction
{
    public class Edge
    {
        public Edge()
        {

        }

        public Edge(int first, int second)
            : this()
        {
            this.First = first;
            this.Second = second;
        }

        public int First { get; set; }

        public int Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} {this.Second}";
        }
    }

    public class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;

        public static void Main()
        {
            var numberOfBuildings = int.Parse(Console.ReadLine());
            var numberOfStreets = int.Parse(Console.ReadLine());

            edges = new List<Edge>();
            graph = ReadGraph(numberOfBuildings, numberOfStreets);
            visited = new bool[numberOfStreets];

            foreach (var edge in edges)
            {
                var firstNode = edge.First;
                var secondNode = edge.Second;

                graph[firstNode].Remove(secondNode); // 1 - 2
                graph[secondNode].Remove(firstNode); // 2 - 1 (reversed)

                DFS(0);

                if (visited[firstNode])
                {
                    var newEdge = new Edge
                    {
                        First = Math.Min(firstNode, secondNode),
                        Second = Math.Max(firstNode, secondNode),
                    };

                    Console.WriteLine(newEdge.ToString());
                }

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            var children = graph[node];

            foreach (var child in children)
            {
                DFS(child);
            }
        }

        private static List<int>[] ReadGraph(int numberOfBuildings, int numberOfStreets)
        {
            var result = new List<int>[numberOfBuildings];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < numberOfStreets; i++)
            {
                var parts = Console.ReadLine()
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                var firstNode = parts[0];
                var secondNode = parts[1];

                result[firstNode].Add(secondNode);
                result[secondNode].Add(firstNode);
                edges.Add(new Edge(firstNode, secondNode));
            }

            return result;
        }
    }
}
