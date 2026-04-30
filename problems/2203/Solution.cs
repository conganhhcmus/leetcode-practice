public class Solution
{
    long INF = 1L << 60;

    public long MinimumWeight(int n, int[][] edges, int src1, int src2, int dest)
    {
        List<int[]>[] g = new List<int[]>[n];
        List<int[]>[] rg = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            g[i] = [];
            rg[i] = [];
        }
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], w = e[2];
            g[u].Add([v, w]);
            rg[v].Add([u, w]);
        }

        long[] dist1 = Dijkstra(g, src1);
        long[] dist2 = Dijkstra(g, src2);
        long[] dist3 = Dijkstra(rg, dest);
        long ans = INF;
        for (int i = 0; i < n; i++)
        {
            // src1 -> i, src2 -> i, i -> dest;
            ans = Math.Min(ans, dist1[i] + dist2[i] + dist3[i]);
        }
        return ans >= INF ? -1 : ans;
    }

    long[] Dijkstra(List<int[]>[] g, int s)
    {
        int n = g.Length;
        long[] dist = new long[n];
        Array.Fill(dist, INF);
        PriorityQueue<int, long> pq = new();
        pq.Enqueue(s, 0);
        dist[s] = 0L;
        while (pq.Count > 0)
        {
            pq.TryDequeue(out int u, out long c);
            if (c > dist[u]) continue;
            foreach (int[] next in g[u])
            {
                int v = next[0], w = next[1];
                long cost = c + w;
                if (cost < dist[v])
                {
                    dist[v] = cost;
                    pq.Enqueue(v, cost);
                }
            }
        }

        return dist;
    }
}
