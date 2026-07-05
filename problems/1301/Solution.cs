public class Solution
{
    public int[] PathsWithMaxScore(IList<string> board)
    {
        int m = board.Count, n = board[0].Length;
        int[,] dp = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = -1;
            }
        }
        dp[m - 1, n - 1] = 0;
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (board[i][j] == 'X') continue;
                int d = (board[i][j] == 'E') ? 0 : (board[i][j] - '0');
                if (i + 1 < m && j + 1 < n && dp[i + 1, j + 1] >= 0)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i + 1, j + 1] + d);
                }
                if (i + 1 < m && dp[i + 1, j] >= 0)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i + 1, j] + d);
                }
                if (j + 1 < n && dp[i, j + 1] >= 0)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i, j + 1] + d);
                }
            }
        }
        int MOD = 1_000_000_007;
        int max = dp[0, 0];
        if (max < 0) return [0, 0];
        long[,,] dp2 = new long[m, n, max + 1];
        dp2[m - 1, n - 1, 0] = 1;
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (board[i][j] == 'X') continue;
                int d = (board[i][j] == 'E') ? 0 : (board[i][j] - '0');
                for (int t = 0; t + d <= max; t++)
                {
                    if (i + 1 < m && j + 1 < n) dp2[i, j, d + t] = (dp2[i, j, d + t] + dp2[i + 1, j + 1, t]) % MOD;
                    if (i + 1 < m) dp2[i, j, d + t] = (dp2[i, j, d + t] + dp2[i + 1, j, t]) % MOD;
                    if (j + 1 < n) dp2[i, j, d + t] = (dp2[i, j, d + t] + dp2[i, j + 1, t]) % MOD;
                }
            }
        }
        int num = (int)dp2[0, 0, max];
        return [max, num];
    }
}
