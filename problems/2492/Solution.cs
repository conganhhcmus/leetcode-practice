public class Solution
{
    public int MinScore(int n, int[][] roads)
    {
        int INF = 1 << 30;
        List<int[]>[] graph = new List<int[]>[n + 1];
        for (int i = 0; i <= n; i++) graph[i] = [];
        foreach (int[] r in roads)
        {
            int u = r[0], v = r[1], w = r[2];
            graph[u].Add([v, w]);
            graph[v].Add([u, w]);
        }
        int[] dist = new int[n + 1];
        Array.Fill(dist, INF);
        Queue<int> queue = [];
        queue.Enqueue(1);
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            foreach (int[] next in graph[u])
            {
                int v = next[0], w = next[1];
                if (Math.Min(dist[u], w) < dist[v])
                {
                    dist[v] = Math.Min(dist[u], w);
                    queue.Enqueue(v);
                }
            }
        }
        return dist[n];
    }
}
