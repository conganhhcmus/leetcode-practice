public class Solution
{
    public int CountGoodStrings(int low, int high, int zero, int one)
    {
        // dp[0] = 1;
        // dp[i] += dp[i-zero] + dp[i-one]

        const int mod = 1_000_000_007;

        long[] dp = new long[high + 1];
        dp[0] = 1;

        for (int j = 1; j <= high; j++)
        {
            if (j - zero >= 0)
            {
                dp[j] = (dp[j] + dp[j - zero]) % mod;
            }
            if (j - one >= 0)
            {
                dp[j] = (dp[j] + dp[j - one]) % mod;
            }
        }


        long ans = 0;
        for (int i = low; i <= high; i++)
        {
            ans = (ans + dp[i]) % mod;
        }

        return (int)ans;
    }
}