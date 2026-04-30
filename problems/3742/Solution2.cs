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
                int cost = Math.Min(1, grid[i][j]);
                int score = grid[i][j];
                for (int t = cost; t <= k; t++)
                {
                    if (i > 0 && dp[i - 1][j][t - cost] != -1)
                    {
                        dp[i][j][t] = Math.Max(dp[i][j][t], dp[i - 1][j][t - cost] + score);
                    }
                    if (j > 0 && dp[i][j - 1][t - cost] != -1)
                    {
                        dp[i][j][t] = Math.Max(dp[i][j][t], dp[i][j - 1][t - cost] + score);
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
