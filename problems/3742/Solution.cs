public class Solution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int s = m * n;
        int[][] dp = new int[s][];
        for (int i = 0; i < s; i++)
        {
            dp[i] = new int[k + 1];
            Array.Fill(dp[i], -1);
        }
        dp[0][0] = 0;
        for (int i = 1; i < m; i++)
        {
            int cost = Math.Min(1, grid[i][0]);
            int score = grid[i][0];
            int id1 = i * n + 0;
            int id2 = (i - 1) * n + 0;
            for (int t = 0; t <= k; t++)
            {
                if (t >= cost && dp[id2][t - cost] != -1)
                {
                    dp[id1][t] = Math.Max(dp[id1][t], dp[id2][t - cost] + score);
                }
            }
        }
        for (int j = 1; j < n; j++)
        {
            int cost = Math.Min(1, grid[0][j]);
            int score = grid[0][j];
            int id1 = 0 * n + j;
            int id2 = 0 * n + j - 1;
            for (int t = 0; t <= k; t++)
            {
                if (t >= cost && dp[id2][t - cost] != -1)
                {
                    dp[id1][t] = Math.Max(dp[id1][t], dp[id2][t - cost] + score);
                }
            }
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                int id = i * n + j;
                int id1 = (i - 1) * n + j;
                int id2 = i * n + j - 1;
                int cost = Math.Min(1, grid[i][j]);
                int score = grid[i][j];
                for (int t = 0; t <= k; t++)
                {
                    if (t >= cost && dp[id1][t - cost] != -1)
                    {
                        dp[id][t] = Math.Max(dp[id][t], dp[id1][t - cost] + score);
                    }
                    if (t >= cost && dp[id2][t - cost] != -1)
                    {
                        dp[id][t] = Math.Max(dp[id][t], dp[id2][t - cost] + score);
                    }
                }
            }
        }
        int ans = -1;
        for (int t = 0; t <= k; t++)
        {
            ans = Math.Max(dp[s - 1][t], ans);
        }
        return ans;
    }
}
