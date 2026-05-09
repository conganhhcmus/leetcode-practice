public class Solution
{
    public int MinimumThreshold(int n, int[][] edges, int source, int target, int k)
    {
        List<int[]>[] graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        int max = 0;
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1], w = e[2];
            graph[u].Add([v, w]);
            graph[v].Add([u, w]);
            if (max < w) max = w;
        }

        int low = 0, high = max, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (Ok(mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans;

        bool Ok(int threshold)
        {
            PriorityQueue<int, int> pq = new();
            int[] dist = new int[n];
            int INF = 1 << 30;
            Array.Fill(dist, INF);
            pq.Enqueue(source, 0);
            dist[source] = 0;
            while (pq.Count > 0)
            {
                pq.TryDequeue(out int u, out int c);
                if (c != dist[u]) continue;
                foreach (int[] next in graph[u])
                {
                    int v = next[0], w = next[1];
                    int extra = w > threshold ? 1 : 0;
                    if (dist[v] > dist[u] + extra)
                    {
                        dist[v] = dist[u] + extra;
                        pq.Enqueue(v, dist[v]);
                    }
                }
            }
            return dist[target] <= k;
        }
    }
}
