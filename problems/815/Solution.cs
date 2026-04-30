public class Solution
{
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        if (source == target) return 0;
        int n = routes.Length;
        Dictionary<int, List<int>> connected = [];
        for (int i = 0; i < n; i++)
        {
            foreach (int j in routes[i])
            {
                if (!connected.ContainsKey(j))
                {
                    connected[j] = [];
                }
                connected[j].Add(i);
            }
        }
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        foreach (List<int> edge in connected.Values)
        {
            int m = edge.Count;
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    int u = edge[i];
                    int v = edge[j];
                    graph[u].Add(v);
                    graph[v].Add(u);
                }
            }
        }
        Queue<int> queue = [];
        int[] dist = new int[n];
        int INF = 1 << 30;
        Array.Fill(dist, INF);
        foreach (int bus in connected.GetValueOrDefault(source, []))
        {
            queue.Enqueue(bus);
            dist[bus] = 1;
        }
        while (queue.Count > 0)
        {
            int s = queue.Count;
            for (int i = 0; i < s; i++)
            {
                int u = queue.Dequeue();
                foreach (int v in graph[u])
                {
                    if (dist[v] > dist[u] + 1)
                    {
                        dist[v] = dist[u] + 1;
                        queue.Enqueue(v);
                    }
                }
            }
        }
        int ans = INF;
        foreach (int t in connected.GetValueOrDefault(target, []))
        {
            ans = Math.Min(ans, dist[t]);
        }
        return ans >= INF ? -1 : ans;
    }
}
