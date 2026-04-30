#pragma warning disable IL2026, IL3050
using System.Text.Json;

public class Graph
{
    int n;
    int[,] dist;
    int INF = 1 << 30;
    public Graph(int n, int[][] edges)
    {
        this.n = n;
        dist = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dist[i, j] = i == j ? 0 : INF;
            }
        }

        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], w = e[2];
            dist[u, v] = Math.Min(dist[u, v], w);
        }

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, k] >= INF || dist[k, j] >= INF) continue;
                    dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                }
            }
        }
    }

    public void AddEdge(int[] edge)
    {
        int u = edge[0], v = edge[1], w = edge[2];
        dist[u, v] = Math.Min(dist[u, v], w);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // dist[i, u] + w + dist[v, j];
                if (dist[i, u] >= INF || dist[v, j] >= INF) continue;
                dist[i, j] = Math.Min(dist[i, j], dist[i, u] + w + dist[v, j]);
            }
        }
    }

    public int ShortestPath(int node1, int node2)
    {
        return dist[node1, node2] >= INF ? -1 : dist[node1, node2];
    }
}

/**
 * Your Graph object will be instantiated and called as such:
 * Graph obj = new Graph(n, edges);
 * obj.AddEdge(edge);
 * int param_2 = obj.ShortestPath(node1,node2);
 */

#if DEBUG
public class Solution
{
    public List<dynamic> Execute(string[] actions, object[] objectList)
    {
        List<dynamic> result = [];
        Graph graph = null;

        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "Graph":
                    object[] data = CastType<object[]>(objectList[i]);
                    int n = CastType<int>(data[0]);
                    int[][] edges = CastType<int[][]>(data[1]);
                    graph = new Graph(n, edges);
                    result.Add(null);
                    break;
                case "addEdge":
                    int[] edge = CastType<int[][]>(objectList[i])[0];
                    graph.AddEdge(edge);
                    result.Add(null);
                    break;
                case "shortestPath":
                    int[] value = CastType<int[]>(objectList[i]);
                    result.Add(graph.ShortestPath(value[0], value[1]));
                    break;
            }
        }
        return result;
    }

    private static T CastType<T>(object value) =>
        ((JsonElement)value).Deserialize<T>(Program.JsonOptions);
}
#endif
