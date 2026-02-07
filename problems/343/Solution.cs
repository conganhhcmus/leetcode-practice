public class Solution
{
    public int IntegerBreak(int n)
    {
        // n = 58
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[n + 1];
        }
        for (int i = 0; i <= n; i++)
        {
            dp[i][0] = i;
        }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                for (int k = 0; k < i; k++)
                {
                    dp[i][j] = Math.Max(dp[i][j], dp[k][j - 1] * (i - k));
                }
            }
        }
        int ret = 0;
        for (int i = 1; i <= n; i++)
        {
            ret = Math.Max(ret, dp[n][i]);
        }
        return ret;
    }
}