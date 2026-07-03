public class Solution
{
    public int FindMaxPathScore(int[][] edges, bool[] online, long k)
    {
        int n = online.Length;
        List<int[]>[] g = new List<int[]>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        int max = 0;
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], c = e[2];
            if (online[u] && online[v]) g[u].Add([v, c]);
            if (max < c) max = c;
        }
        int lo = 0, hi = max, ans = -1;
        while (lo <= hi)
        {
            int mi = lo + (hi - lo) / 2;
            if (Ok(mi))
            {
                ans = mi;
                lo = mi + 1;
            }
            else
            {
                hi = mi - 1;
            }
        }
        return ans;

        bool Ok(int val)
        {
            long[] dist = new long[n];
            Array.Fill(dist, k + 1);
            dist[0] = 0;
            PriorityQueue<int, long> pq = new();
            pq.Enqueue(0, 0L);
            while (pq.Count > 0)
            {
                pq.TryDequeue(out int u, out long t);
                if (dist[u] != t) continue;
                if (u == n - 1) return dist[u] <= k;
                foreach (int[] nei in g[u])
                {
                    int v = nei[0], c = nei[1];
                    long sc = dist[u] + c;
                    if (c >= val && sc <= k && sc < dist[v])
                    {
                        dist[v] = sc;
                        pq.Enqueue(v, sc);
                    }
                }
            }
            return false;
        }
    }
}
