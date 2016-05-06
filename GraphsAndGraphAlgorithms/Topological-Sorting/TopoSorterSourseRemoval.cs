using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topological_Sorting_DFS
{
    public class TopoSorterSourseRemoval
    {
        private readonly Dictionary<string, List<string>> graph;

        private readonly Dictionary<string, int> predeccCount;

        public TopoSorterSourseRemoval(Dictionary<string, List<string>> graph)
        {
            this.graph = graph;
            this.predeccCount = new Dictionary<string, int>();
            this.CountPredeccessors();
        }

        public ICollection<string> TopSort()
        {
            var removedNodes = new List<string>();
            var vertextes = this.predeccCount.Keys.ToList();

            while (removedNodes.Count < this.graph.Count)
            {
                foreach (var vertex in vertextes)
                {
                    if (this.predeccCount[vertex] == 0 && !removedNodes.Contains(vertex))
                    {
                        removedNodes.Add(vertex);

                        if (this.graph.ContainsKey(vertex))
                        {
                            foreach (var vert in this.graph[vertex])
                            {
                                this.predeccCount[vert]--;
                            }
                        }
                    }
                }
            }

            return removedNodes;
        }

        private void CountPredeccessors()
        {
            foreach (var vertex in this.graph)
            {
                if (!this.predeccCount.ContainsKey(vertex.Key))
                {
                    this.predeccCount[vertex.Key] = 0;
                }

                foreach (var vert in vertex.Value)
                {
                    if (!this.predeccCount.ContainsKey(vert))
                    {
                        this.predeccCount[vert] = 0;
                    }

                    this.predeccCount[vert]++;
                }
            }
        }
    }
}
