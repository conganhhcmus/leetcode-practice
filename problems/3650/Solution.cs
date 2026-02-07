public class Solution
{
    public int MinCost(int n, int[][] edges)
    {
        List<int[]>[] adj = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = [];
        }
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], w = e[2];
            adj[u].Add([v, w]);
            adj[v].Add([u, 2 * w]);
        }
        int[] dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        dist[0] = 0;
        PriorityQueue<int, int> pq = new();
        pq.Enqueue(0, 0);
        while (pq.Count > 0)
        {
            int cur = pq.Dequeue();
            foreach (var next in adj[cur])
            {
                if (dist[cur] + next[1] < dist[next[0]])
                {
                    dist[next[0]] = dist[cur] + next[1];
                    pq.Enqueue(next[0], dist[next[0]]);
                }
            }
        }
        if (dist[n - 1] == int.MaxValue) return -1;
        return dist[n - 1];
    }
}