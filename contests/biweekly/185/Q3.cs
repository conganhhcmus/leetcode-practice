public class Solution
{
    public long FinishTime(int n, int[][] edges, int[] baseTime)
    {
        long INF = 1L << 60;
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        int[] degree = new int[n];
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1];
            g[v].Add(u);
            degree[u]++;
        }
        long[][] f = new long[n][];
        for (int i = 0; i < n; i++)
        {
            f[i] = [INF, -INF];
        }
        Queue<int> queue = [];
        for (int i = 0; i < n; i++)
        {
            if (degree[i] == 0) queue.Enqueue(i);
        }
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            long need = f[u][0] == INF ? baseTime[u] : 2L * f[u][1] - f[u][0] + baseTime[u];
            foreach (int v in g[u])
            {
                f[v][0] = Math.Min(f[v][0], need);
                f[v][1] = Math.Max(f[v][1], need);
                degree[v]--;
                if (degree[v] == 0) queue.Enqueue(v);
            }
        }
        if (f[0][0] == INF) return baseTime[0];
        return 2L * f[0][1] - f[0][0] + baseTime[0];
    }
}
