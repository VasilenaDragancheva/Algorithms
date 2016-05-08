namespace FindCyclesInGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static HashSet<char> allVertexes = new HashSet<char>();

        public static HashSet<char> currentDFs = new HashSet<char>();

        public static List<Tuple<char, char>> graph;

        public static bool isAcyclic = true;

        public static bool[] visitedTuples;

        public static void Main(string[] args)
        {
            graph = new List<Tuple<char, char>>();

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                var input = line.Split(new[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var item1 = char.Parse(input[0]);
                var item2 = char.Parse(input[1]);
                graph.Add(new Tuple<char, char>(item1, item2));
                allVertexes.Add(item1);
                allVertexes.Add(item2);
            }

            visitedTuples = new bool[graph.Count];

            foreach (var vertex in allVertexes)
            {
                Dfs(vertex);
            }
        }

        private static void Dfs(char vertex)
        {
            if (currentDFs.Contains(vertex))
            {
                isAcyclic = false;
                return;
            }

            currentDFs.Add(vertex);
            for (int i = 0; i < graph.Count; i++)
            {
                if (!visitedTuples[i])
                {
                    if (graph[i].Item1 == vertex)
                    {
                        visitedTuples[i] = true;
                        Dfs(graph[i].Item2);
                    }

                    if (graph[i].Item2 == vertex)
                    {
                        visitedTuples[i] = true;
                        Dfs(graph[i].Item1);
                    }
                }
            }


            currentDFs.Remove(vertex);
        }
    }
}