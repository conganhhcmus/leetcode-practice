public class Solution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int[][][] dp = new int[m][][];
        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n][];
            for (int j = 0; j < n; j++)
            {
                dp[i][j] = new int[k + 1];
                Array.Fill(dp[i][j], -1);
            }
        }
        dp[0][0][0] = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int c = 0; c <= k; c++)
                {
                    if (dp[i][j][c] == -1) continue;
                    if (i + 1 < m)
                    {
                        int cost = Math.Min(1, grid[i + 1][j]);
                        int score = grid[i + 1][j];
                        if (c + cost <= k) dp[i + 1][j][c + cost] = Math.Max(dp[i + 1][j][c + cost], dp[i][j][c] + score);
                    }
                    if (j + 1 < n)
                    {
                        int cost = Math.Min(1, grid[i][j + 1]);
                        int score = grid[i][j + 1];
                        if (c + cost <= k) dp[i][j + 1][c + cost] = Math.Max(dp[i][j + 1][c + cost], dp[i][j][c] + score);
                    }
                }
            }
        }
        int ans = -1;
        for (int t = 0; t <= k; t++)
        {
            ans = Math.Max(ans, dp[m - 1][n - 1][t]);
        }
        return ans;
    }
}
