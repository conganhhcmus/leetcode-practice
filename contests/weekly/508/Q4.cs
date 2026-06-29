public class Solution
{
    public long[] MinTimeMaxPower(int n, int[][] edges, int power, int[] cost, int source, int target)
    {
        long INF = 1L << 60;
        List<int[]>[] g = new List<int[]>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        foreach (int[] e in edges) g[e[0]].Add([e[1], e[2]]);
        PriorityQueue<int, (long time, long remain)> pq = new(Comparer<(long time, long remain)>.Create((a, b) =>
        {
            int cmp = a.time.CompareTo(b.time);
            if (cmp != 0) return cmp;
            return b.remain.CompareTo(a.remain);
        }));

        long[,] dp = new long[n, power + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= power; j++)
            {
                dp[i, j] = INF;
            }
        }

        dp[source, power] = 0;
        pq.Enqueue(source, (0, power));

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int u, out var cur);
            var (time, remain) = cur;
            if (time != dp[u, remain]) continue;
            long nRemain = remain - cost[u];
            if (nRemain < 0) continue;
            foreach (var e in g[u])
            {
                int v = e[0];
                long nTime = time + e[1];
                if (nTime >= dp[v, nRemain]) continue;
                dp[v, nRemain] = nTime;
                pq.Enqueue(v, (nTime, nRemain));
            }
        }
        long minT = INF;
        long maxP = -1;
        for (int i = 0; i <= power; i++)
        {
            if (minT > dp[target, i])
            {
                minT = dp[target, i];
                maxP = i;
            }
            else if (minT == dp[target, i])
            {
                maxP = i;
            }
        }
        if (minT == INF) return [-1, -1];
        return [minT, maxP];
    }
}
