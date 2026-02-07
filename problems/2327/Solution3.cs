public class Solution
{
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        // dp[i] = sharing people at i-th day
        int mod = (int)1e9 + 7;
        int[] dp = new int[n + 1];
        dp[1] = 1;
        int sharing = 0;
        for (int d = 2; d <= n; d++)
        {
            if (d - delay >= 1) sharing = (sharing + dp[d - delay]) % mod;
            if (d - forget >= 1) sharing = (sharing - dp[d - forget] + mod) % mod;
            dp[d] = sharing;
        }

        int ret = 0;
        for (int d = n - forget + 1; d <= n; d++)
        {
            ret = (ret + dp[d]) % mod;
        }
        return ret;
    }
}