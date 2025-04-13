#if DEBUG
namespace Biweekly_154_Q4;
#endif

public class Solution
{
    public int[] TreeQueries(int n, int[][] edges, int[][] queries)
    {
        Graph graph = new(n + 1);
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            graph.AddOrUpdateEdge(u, v, w);
            graph.AddOrUpdateEdge(v, u, w);
        }

        graph.Dijkstra(1);
        List<int> ret = [];
        foreach (int[] query in queries)
        {
            if (query.Length == 4)
            {
                int u = query[1], v = query[2], w = query[3];
                graph.AddOrUpdateEdge(u, v, w);
                graph.AddOrUpdateEdge(v, u, w);
                graph.Dijkstra(1);
            }
            else
            {
                ret.Add(graph.GetDistance(query[1]));
            }
        }
        return [.. ret];
    }
}


public class Graph
{
    Dictionary<int, Dictionary<int, int>> graph;
    int[] dist; // distance
    int v; // vertices

    public Graph(int v)
    {
        this.v = v;
        graph = [];
        dist = new int[v];
        for (int i = 0; i < v; i++)
        {
            dist[i] = int.MaxValue;
            graph[i] = [];
        }
    }

    public void AddOrUpdateEdge(int u, int v, int w)
    {
        graph[u].TryAdd(v, w);
        graph[u][v] = w;
    }

    // dijkstra with priority queue
    public void Dijkstra(int src)
    {
        PriorityQueue<int, int> pq = new();
        Array.Fill(dist, int.MaxValue);
        dist[src] = 0;
        pq.Enqueue(src, 0);
        while (pq.Count > 0)
        {
            int u = pq.Dequeue();
            foreach (var neighbor in graph.GetValueOrDefault(u, []))
            {
                int v = neighbor.Key;
                int w = neighbor.Value;
                if (dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    pq.Enqueue(v, dist[v]);
                }
            }
        }
    }

    public int GetDistance(int target)
    {
        return dist[target];
    }
}