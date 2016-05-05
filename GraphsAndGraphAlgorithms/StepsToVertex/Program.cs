using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsToVertex
{
    using System.ComponentModel;

    public class Program
    {
        public static Dictionary<int, List<int>> graph;

        public static void Main(string[] args)
        {
            var line = Console.ReadLine();

            graph = new Dictionary<int, List<int>>();

            while (true)
            {
                line = Console.ReadLine();
                if (line.Contains("Distances"))
                {
                    break;
                }

                var parts = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var key = int.Parse(parts[0]);
                var vertexes = parts.Skip(2).Select(int.Parse).ToList();
                graph.Add(key, vertexes);
            }

            while (true)
            {
                string distances = Console.ReadLine();
                if (string.IsNullOrEmpty(distances))
                {
                    break;

                }

                var parts = distances.Split('-').Select(int.Parse).ToArray();
                var start = parts[0];
                var end = parts[1];
                var steps = BFS(start, end);
                Console.WriteLine("{0} {1}", distances, steps);
            }
        }

        private static int BFS(int start, int end)
        {
            var visited = new HashSet<int>();
            int steps = -1;

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(start, 0));

            while (queue.Count > 0)
            {
                var value = queue.Dequeue();
                visited.Add(value.Item1);

                if (value.Item1 == end)
                {
                    return value.Item2;
                }

                foreach (var vertex in graph[value.Item1])
                {
                    if (!visited.Contains(vertex))
                    {
                        queue.Enqueue(new Tuple<int, int>(vertex, value.Item2 + 1));
                    }
                }
            }

            return steps;
        }
    }
}
