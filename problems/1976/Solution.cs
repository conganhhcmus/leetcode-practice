#if DEBUG
namespace Problems_1976;
#endif

public class Solution
{
    public int CountPaths(int n, int[][] roads)
    {
        int mod = 1000000007;
        List<int[]>[] graph = new List<int[]>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        foreach (int[] road in roads)
        {
            int u = road[0], v = road[1], w = road[2];
            graph[u].Add([v, w]);
            graph[v].Add([u, w]);
        }

        long[] dist = new long[n];
        int[] ways = new int[n];
        Array.Fill(dist, long.MaxValue);
        PriorityQueue<(int, long), long> pq = new();
        pq.Enqueue((0, 0), 0);
        dist[0] = 0;
        ways[0] = 1;
        while (pq.Count > 0)
        {
            var (u, d) = pq.Dequeue();
            if (d > dist[u]) continue;
            foreach (var neighbor in graph[u])
            {
                int v = neighbor[0], w = neighbor[1];
                if (dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    ways[v] = ways[u];
                    pq.Enqueue((v, dist[v]), dist[v]);
                }
                else if (dist[u] + w == dist[v])
                {
                    ways[v] = (ways[v] + ways[u]) % mod;
                }
                else
                {
                    // do nothing
                }
            }
        }

        return ways[n - 1];
    }
}