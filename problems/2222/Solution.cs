public class Solution
{
    public long NumberOfWays(string s)
    {
        // n = 10^5
        int n = s.Length;
        long[,,] dp = new long[n + 1, 4, 2];
        for (int i = 0; i <= n; i++)
        {
            dp[i, 0, 0] = 1;
            dp[i, 0, 1] = 1;
        }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                dp[i, j, 0] += dp[i - 1, j, 0];
                dp[i, j, 1] += dp[i - 1, j, 1];
                if (s[i - 1] == '0')
                {
                    dp[i, j, 0] += dp[i - 1, j - 1, 1];
                }
                else
                {
                    dp[i, j, 1] += dp[i - 1, j - 1, 0];
                }
            }
        }

        return dp[n, 3, 0] + dp[n, 3, 1];
    }
}