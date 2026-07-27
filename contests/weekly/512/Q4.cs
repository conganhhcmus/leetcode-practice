public class Solution
{
    public record State(int X, int Y, int T);

    public long MinCost(int m, int n, int[][] penalty)
    {
        long INF = 1L << 60;
        long[,,] dp = new long[m, n, 2];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    dp[i, j, k] = INF;
                }
            }
        }

        dp[0, 0, 0] = 1;
        PriorityQueue<State, long> pq = new();
        pq.Enqueue(new(0, 0, 0), 1);
        while (pq.Count > 0)
        {
            pq.TryDequeue(out var cur, out long d);
            if (d != dp[cur.X, cur.Y, cur.T]) continue;
            int x = cur.X;
            int y = cur.Y;
            int t = cur.T;
            long dist = dp[x, y, t];
            int nT = t ^ 1;
            if (t == 0)
            {
                // move right, down
                if (x + 1 < m)
                {
                    long cost = dist + 1L * (x + 1 + 1) * (y + 1);
                    if (cost < dp[x + 1, y, nT])
                    {
                        dp[x + 1, y, nT] = cost;
                        pq.Enqueue(new(x + 1, y, nT), cost);
                    }
                }
                if (y + 1 < n)
                {
                    long cost = dist + 1L * (x + 1) * (y + 1 + 1);
                    if (cost < dp[x, y + 1, nT])
                    {
                        dp[x, y + 1, nT] = cost;
                        pq.Enqueue(new(x, y + 1, nT), cost);
                    }
                }
                // vilates
                if (x - 1 >= 0)
                {
                    long cost = dist + penalty[x][y] + 1L * (x - 1 + 1) * (y + 1);
                    if (cost < dp[x - 1, y, nT])
                    {
                        dp[x - 1, y, nT] = cost;
                        pq.Enqueue(new(x - 1, y, nT), cost);
                    }
                }
                if (y - 1 >= 0)
                {
                    long cost = dist + penalty[x][y] + 1L * (x + 1) * (y - 1 + 1);
                    if (cost < dp[x, y - 1, nT])
                    {
                        dp[x, y - 1, nT] = cost;
                        pq.Enqueue(new(x, y - 1, nT), cost);
                    }
                }
            }
            else
            {
                // move left, up
                if (x - 1 >= 0)
                {
                    long cost = dist + 1L * (x - 1 + 1) * (y + 1);
                    if (cost < dp[x - 1, y, nT])
                    {
                        dp[x - 1, y, nT] = cost;
                        pq.Enqueue(new(x - 1, y, nT), cost);
                    }
                }
                if (y - 1 >= 0)
                {
                    long cost = dist + 1L * (x + 1) * (y - 1 + 1);
                    if (cost < dp[x, y - 1, nT])
                    {
                        dp[x, y - 1, nT] = cost;
                        pq.Enqueue(new(x, y - 1, nT), cost);
                    }
                }
                // vilates
                if (x + 1 < m)
                {
                    long cost = dist + penalty[x][y] + 1L * (x + 1 + 1) * (y + 1);
                    if (cost < dp[x + 1, y, nT])
                    {
                        dp[x + 1, y, nT] = cost;
                        pq.Enqueue(new(x + 1, y, nT), cost);
                    }
                }
                if (y + 1 < n)
                {
                    long cost = dist + penalty[x][y] + 1L * (x + 1) * (y + 1 + 1);
                    if (cost < dp[x, y + 1, nT])
                    {
                        dp[x, y + 1, nT] = cost;
                        pq.Enqueue(new(x, y + 1, nT), cost);
                    }
                }
            }
            if (dist + penalty[x][y] < dp[x, y, nT])
            {
                dp[x, y, nT] = dist + penalty[x][y];
                pq.Enqueue(new(x, y, nT), dist + penalty[x][y]);
            }
        }

        return Math.Min(dp[m - 1, n - 1, 0], dp[m - 1, n - 1, 1]);
    }
}
