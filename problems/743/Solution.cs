public class Solution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        int INF = 1 << 30;
        List<int[]>[] graph = new List<int[]>[n + 1];
        for (int i = 0; i <= n; i++) graph[i] = [];
        foreach (int[] e in times)
        {
            int u = e[0], v = e[1], w = e[2];
            graph[u].Add([v, w]);
        }
        int[] dist = new int[n + 1];
        Array.Fill(dist, INF);
        Queue<int> queue = [];
        queue.Enqueue(k);
        dist[k] = 0;
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            foreach (int[] next in graph[u])
            {
                int v = next[0], w = next[1];
                if (dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    queue.Enqueue(v);
                }
            }
        }

        int ans = -1;
        for (int i = 1; i <= n; i++)
        {
            ans = Math.Max(ans, dist[i]);
        }
        return ans >= INF ? -1 : ans;
    }
}
