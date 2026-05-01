public class Solution
{
    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
    {
        int INF = 1 << 30;
        int[,] dist = new int[n, n];
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
            dist[v, u] = Math.Min(dist[v, u], w);
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
        int[] count = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (dist[i, j] <= distanceThreshold)
                {
                    count[i]++;
                    count[j]++;
                }
            }
        }
        int min = count.Min();
        for (int i = n - 1; i >= 0; i--)
        {
            if (count[i] == min) return i;
        }
        return -1;
    }
}
