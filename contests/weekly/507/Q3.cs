public class Solution
{
    public int ShortestPath(int n, int[][] edges, string labels, int k)
    {
        List<int[]>[] g = new List<int[]>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], w = e[2];
            g[u].Add([v, w]);
        }
        int INF = 1 << 30;
        int[] dist = new int[n];
        Array.Fill(dist, INF);
        dist[0] = 0;
        PriorityQueue<int[], int> pq = new();
        pq.Enqueue([0, 1], 0);
        while (pq.Count > 0)
        {
            pq.TryDequeue(out int[] cur, out int d);
            int u = cur[0], c = cur[1];
            if (d > dist[u]) continue;
            foreach (int[] next in g[u])
            {
                int v = next[0], w = next[1];
                int nC = (labels[u] == labels[v]) ? c + 1 : 1;
                int cost = dist[u] + w;
                if (nC > k || cost >= dist[v]) continue;
                dist[v] = cost;
                pq.Enqueue([v, nC], cost);
            }
        }
        if (dist[n - 1] == INF) return -1;
        return dist[n - 1];
    }
}
