using System;
using System.Collections.Generic;

public class TopologicalSorter
{
    private readonly Dictionary<string, List<string>> graph;

    private readonly HashSet<string> visited;

    private readonly HashSet<string> currentDfs;

    private readonly LinkedList<string> topSorted;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
        this.visited = new HashSet<string>();
        this.topSorted = new LinkedList<string>();
        this.currentDfs = new HashSet<string>();
    }

    public ICollection<string> TopSort()
    {
        foreach (var vertex in this.graph)
        {
            this.DfsTopSort(vertex.Key);
        }

        return this.topSorted;
    }

    private void DfsTopSort(string vertex)
    {
        if (this.currentDfs.Contains(vertex))
        {
            throw new InvalidOperationException();
        }

        if (!this.visited.Contains(vertex))
        {
            this.visited.Add(vertex);
            this.currentDfs.Add(vertex);

            if (this.graph.ContainsKey(vertex))
            {
                foreach (var vert in this.graph[vertex])
                {
                    this.DfsTopSort(vert);
                }
            }

            this.topSorted.AddFirst(vertex);
            this.currentDfs.Remove(vertex);
        }
    }
}