using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SourceRemovalTopologicalSorting
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            dependencies = ExtractDependencies();

            var result = TopologicalSort();

            if (result.Count == 0)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", result)}");
            }
        }

        private static List<string> TopologicalSort()
        {
            var result = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies
                                    .FirstOrDefault(d => d.Value == 0);

                if (nodeToRemove.Key == null)
                {
                    break;
                }

                var node = nodeToRemove.Key;
                var children = graph[node];


                foreach (var child in children)
                {
                    dependencies[child]--;
                }

                result.Add(node);
                dependencies.Remove(nodeToRemove.Key);
            }

            return result;
        }

        private static Dictionary<string, int> ExtractDependencies()
        {
            var dependenciesResult = new Dictionary<string, int>();

            foreach (var node in graph)
            {
                var key = node.Key;
                var children = node.Value;

                if (dependenciesResult.ContainsKey(key) == false)
                {
                    dependenciesResult.Add(key, 0);
                }

                foreach (var child in children)
                {
                    if (dependenciesResult.ContainsKey(child) == false)
                    {
                        dependenciesResult.Add(child, 1);
                    }
                    else
                    {
                        dependenciesResult[child]++;
                    }
                }
            }

            return dependenciesResult;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var graphResult = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine()
                            .Split("->", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                var key = parts[0].Trim();

                if (parts.Length == 1)
                {
                    graphResult[key] = new List<string>();
                }
                else
                {
                    var children = parts[1]
                                    .Trim()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

                    graphResult[key] = children;
                }
            }

            return graphResult;
        }
    }
}
