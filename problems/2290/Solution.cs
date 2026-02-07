
public class Solution
{
    public int MinimumObstacles(int[][] grid)
    {
        return MinimumObstacles_Dijkstra(grid);
    }

    private int MinimumObstacles_Dijkstra(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int[] directions = [0, 1, 0, -1, 0];
        int[,] dp = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                dp[i, j] = int.MaxValue;

        dp[0, 0] = grid[0][0];
        var deque = new LinkedList<(int r, int c)>();
        deque.AddFirst((0, 0));
        while (deque.Count > 0)
        {
            var (r, c) = deque.First.Value;
            deque.RemoveFirst();
            for (int i = 0; i < directions.Length - 1; i++)
            {
                var (nextR, nextC) = (r + directions[i], c + directions[i + 1]);
                if (nextR < 0 || nextR >= m || nextC < 0 || nextC >= n) continue;

                if (dp[nextR, nextC] > dp[r, c] + grid[nextR][nextC])
                {
                    dp[nextR, nextC] = dp[r, c] + grid[nextR][nextC];
                    if (grid[nextR][nextC] == 1)
                    {
                        deque.AddLast((nextR, nextC));
                    }
                    else
                    {
                        deque.AddFirst((nextR, nextC));
                    }
                }
            }
        }

        return dp[m - 1, n - 1];
    }

    private int MinimumObstacles_PriorityQueue(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int minRemove = m + n - 1;
        PriorityQueue<(int r, int c, int obstacles), int> queue = new();
        int[,] visited = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                visited[i, j] = int.MaxValue;
            }
        }
        queue.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        visited[0, 0] = grid[0][0];
        while (queue.Count > 0)
        {
            var (r, c, obstacles) = queue.Dequeue();
            if (r == m - 1 && c == n - 1)
            {
                minRemove = Math.Min(minRemove, obstacles);
                break;
            }

            if (r + 1 < m && obstacles + grid[r + 1][c] < visited[r + 1, c])
            {
                queue.Enqueue((r + 1, c, obstacles + grid[r + 1][c]), obstacles + grid[r + 1][c]);
                visited[r + 1, c] = obstacles + grid[r + 1][c];
            }

            if (r - 1 >= 0 && obstacles + grid[r - 1][c] < visited[r - 1, c])
            {
                queue.Enqueue((r - 1, c, obstacles + grid[r - 1][c]), obstacles + grid[r - 1][c]);
                visited[r - 1, c] = obstacles + grid[r - 1][c];
            }

            if (c + 1 < n && obstacles + grid[r][c + 1] < visited[r, c + 1])
            {
                queue.Enqueue((r, c + 1, obstacles + grid[r][c + 1]), obstacles + grid[r][c + 1]);
                visited[r, c + 1] = obstacles + grid[r][c + 1];
            }

            if (c - 1 >= 0 && obstacles + grid[r][c - 1] < visited[r, c - 1])
            {
                queue.Enqueue((r, c - 1, obstacles + grid[r][c - 1]), obstacles + grid[r][c - 1]);
                visited[r, c - 1] = obstacles + grid[r][c - 1];
            }
        }
        return minRemove;
    }
}