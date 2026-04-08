public class Solution
{
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        int n = grid.Count;
        int INF = int.MaxValue;
        int[][] dist = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dist[i] = new int[n];
            Array.Fill(dist[i], INF);
        }

        Queue<(int x, int y)> queue = [];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    dist[i][j] = 0;
                    queue.Enqueue((i, j));
                }
            }
        }
        int l = 0;
        int[] dirs = [1, 0, -1, 0, 1];
        while (queue.Count > 0)
        {
            int size = queue.Count;
            l++;
            for (int i = 0; i < size; i++)
            {
                var (x, y) = queue.Dequeue();
                for (int d = 0; d < 4; d++)
                {
                    int x1 = x + dirs[d];
                    int y1 = y + dirs[d + 1];
                    if (x1 >= 0 && y1 >= 0 && x1 < n && y1 < n && dist[x1][y1] == INF)
                    {
                        dist[x1][y1] = l;
                        queue.Enqueue((x1, y1));
                    }
                }
            }
        }

        int[][] fn = new int[n][];
        for (int i = 0; i < n; i++)
        {
            fn[i] = new int[n];
        }
        fn[0][0] = dist[0][0];
        queue.Clear();
        queue.Enqueue((0, 0));
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            for (int d = 0; d < 4; d++)
            {
                int x1 = x + dirs[d];
                int y1 = y + dirs[d + 1];
                if (x1 >= 0 && y1 >= 0 && x1 < n && y1 < n)
                {
                    if (Math.Min(fn[x][y], dist[x1][y1]) > fn[x1][y1])
                    {
                        fn[x1][y1] = Math.Min(fn[x][y], dist[x1][y1]);
                        queue.Enqueue((x1, y1));
                    }
                }
            }
        }
        return fn[n - 1][n - 1];
    }

    int Dist(int x, int y, IList<IList<int>> grid)
    {
        int dist = int.MaxValue;
        int n = grid.Count;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    dist = Math.Min(dist, Math.Abs(x - i) + Math.Abs(y - j));
                }
            }
        }
        return dist;
    }
}