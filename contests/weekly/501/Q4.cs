public class Solution
{
    public int[] MinCost(int n, int[] prices, int[][] roads)
    {
        List<int[]>[] graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] r in roads)
        {
            int u = r[0], v = r[1], c = r[2], t = r[3];
            graph[u].Add([v, c, t]);
            graph[v].Add([u, c, t]);
        }
        int[,] cost1 = new int[n, n]; // cost without carry apples
        int[,] cost2 = new int[n, n]; // cost with tax
        int INF = 1 << 30;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cost1[i, j] = INF;
                cost2[i, j] = INF;
            }
        }
        // build cost1
        for (int i = 0; i < n; i++)
        {
            cost1[i, i] = 0;
            PriorityQueue<int, int> pq = new();
            pq.Enqueue(i, 0);
            while (pq.Count > 0)
            {
                pq.TryDequeue(out int u, out int p);
                if (cost1[i, u] != p) continue;
                foreach (int[] next in graph[u])
                {
                    int v = next[0], c = next[1], t = next[2];
                    if (cost1[i, v] > cost1[i, u] + c)
                    {
                        cost1[i, v] = cost1[i, u] + c;
                        pq.Enqueue(v, cost1[i, v]);
                    }
                }
            }
        }

        // build cost2
        for (int i = 0; i < n; i++)
        {
            PriorityQueue<int, int> pq = new();
            pq.Enqueue(i, 0);
            cost2[i, i] = 0;
            while (pq.Count > 0)
            {
                pq.TryDequeue(out int u, out int p);
                if (cost2[i, u] != p) continue;
                foreach (int[] next in graph[u])
                {
                    int v = next[0], c = next[1], t = next[2];
                    if (1L * c * t > INF) continue;
                    int a = c * t;
                    if (cost2[i, v] > cost2[i, u] + a)
                    {
                        cost2[i, v] = cost2[i, u] + a;
                        pq.Enqueue(v, cost2[i, v]);
                    }
                }
            }
        }

        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int best = INF;
            for (int j = 0; j < n; j++)
            {
                if (best > 1L * cost1[i, j] + cost2[j, i] + prices[j])
                {
                    best = Math.Min(best, cost1[i, j] + cost2[j, i] + prices[j]);
                }
            }
            ans[i] = best;
        }
        return ans;
    }
}
