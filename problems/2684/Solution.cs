public class Solution
{
    public int MaxMoves(int[][] grid)
    {
        return MaxMoves_BFS(grid);
    }
    private int MaxMoves_BFS(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int maxMove = 0;

        bool[][] map = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            map[i] = new bool[n];
        }

        Queue<(int r, int c, int len)> queue = [];
        for (int i = 0; i < m; i++)
        {
            queue.Enqueue((i, 0, 0));
            map[i][0] = true;
        }

        while (queue.Count > 0)
        {
            var (r, c, len) = queue.Dequeue();

            maxMove = Math.Max(maxMove, len);


            if (r - 1 >= 0 && c + 1 < n && grid[r][c] < grid[r - 1][c + 1] && map[r - 1][c + 1] == false)
            {
                queue.Enqueue((r - 1, c + 1, len + 1));
                map[r - 1][c + 1] = true;
            }

            if (c + 1 < n && grid[r][c] < grid[r][c + 1] && map[r][c + 1] == false)
            {
                queue.Enqueue((r, c + 1, len + 1));
                map[r][c + 1] = true;
            }

            if (r + 1 < m && c + 1 < n && grid[r][c] < grid[r + 1][c + 1] && map[r + 1][c + 1] == false)
            {
                queue.Enqueue((r + 1, c + 1, len + 1));
                map[r + 1][c + 1] = true;
            }
        }

        return maxMove;
    }

    private int MaxMoves_DP(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] dp = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
        }

        for (int col = n - 2; col >= 0; col--)
        {
            for (int row = 0; row < m; row++)
            {
                int max = 0;
                if (row - 1 >= 0 && grid[row][col] < grid[row - 1][col + 1])
                {
                    max = Math.Max(max, dp[row - 1][col + 1] + 1);
                }

                if (grid[row][col] < grid[row][col + 1])
                {
                    max = Math.Max(max, dp[row][col + 1] + 1);
                }

                if (row + 1 < m && grid[row][col] < grid[row + 1][col + 1])
                {
                    max = Math.Max(max, dp[row + 1][col + 1] + 1);
                }

                dp[row][col] = max;
            }
        }

        return dp.Max(x => x[0]);
    }
}