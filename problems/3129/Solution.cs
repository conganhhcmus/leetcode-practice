public class Solution
{
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        int mod = (int)1e9 + 7;
        long[,,] dp = new long[zero + 1, one + 1, 2];
        for (int i = 0; i <= Math.Min(zero, limit); i++)
        {
            dp[i, 0, 0] = 1;
        }
        for (int i = 0; i <= Math.Min(one, limit); i++)
        {
            dp[0, i, 1] = 1;
        }
        for (int i = 1; i <= zero; i++)
        {
            for (int j = 1; j <= one; j++)
            {
                if (i > limit)
                {
                    dp[i, j, 0] = dp[i - 1, j, 1] + dp[i - 1, j, 0] - dp[i - limit - 1, j, 1];
                }
                else
                {
                    dp[i, j, 0] = dp[i - 1, j, 1] + dp[i - 1, j, 0];
                }
                dp[i, j, 0] = (dp[i, j, 0] % mod + mod) % mod;
                if (j > limit)
                {
                    dp[i, j, 1] = dp[i, j - 1, 0] + dp[i, j - 1, 1] - dp[i, j - limit - 1, 0];
                }
                else
                {
                    dp[i, j, 1] = dp[i, j - 1, 0] + dp[i, j - 1, 1];
                }
                dp[i, j, 1] = (dp[i, j, 1] % mod + mod) % mod;
            }
        }

        long ans = (dp[zero, one, 0] + dp[zero, one, 1]) % mod;
        return (int)ans;
    }
}