public class Graph
{
    int n;
    List<int[]>[] graph;
    public Graph(int n, int[][] edges)
    {
        this.n = n;
        graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], w = e[2];
            graph[u].Add([v, w]);
        }
    }

    public void AddEdge(int[] edge)
    {
        int u = edge[0], v = edge[1], w = edge[2];
        graph[u].Add([v, w]);
    }

    public int ShortestPath(int node1, int node2)
    {
        int INF = 1 << 30;
        int[] dist = new int[n];
        Array.Fill(dist, INF);
        PriorityQueue<int, int> pq = new();
        pq.Enqueue(node1, 0);
        dist[node1] = 0;
        while (pq.Count > 0)
        {
            pq.TryDequeue(out int u, out int d);
            if (u == node2) return dist[u];
            if (d > dist[u]) continue;
            foreach (int[] nei in graph[u])
            {
                int v = nei[0], w = nei[1];
                if (d + w < dist[v])
                {
                    dist[v] = d + w;
                    pq.Enqueue(v, d + w);
                }
            }
        }
        return -1;
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
    public List<dynamic> Execute(string[] actions, object[] values)
    {
        List<dynamic> result = [];
        Graph graph = null;

        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "Graph":
                    object[] data = CastType<object[]>(values[i]);
                    int n = CastType<int>(data[0]);
                    int[][] edges = CastType<int[][]>(data[1]);
                    graph = new Graph(n, edges);
                    result.Add(null);
                    break;
                case "addEdge":
                    int[] edge = CastType<int[][]>(values[i])[0];
                    graph.AddEdge(edge);
                    result.Add(null);
                    break;
                case "shortestPath":
                    int[] value = CastType<int[]>(values[i]);
                    result.Add(graph.ShortestPath(value[0], value[1]));
                    break;
            }
        }
        return result;
    }

    private static T CastType<T>(object value) => ((JsonElement)value).Deserialize<T>(Program.JsonOptions);
}
#endif
