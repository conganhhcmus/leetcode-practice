public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int[][] dp = new int[m][];

        int INF = 1 << 30;

        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0) dp[i][j] = 0;
                else dp[i][j] = INF;
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i > 0) dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j] + 1);
                if (j > 0) dp[i][j] = Math.Min(dp[i][j], dp[i][j - 1] + 1);
            }
        }

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (i < m - 1) dp[i][j] = Math.Min(dp[i][j], dp[i + 1][j] + 1);
                if (j < n - 1) dp[i][j] = Math.Min(dp[i][j], dp[i][j + 1] + 1);
            }
        }

        return dp;
    }
}
