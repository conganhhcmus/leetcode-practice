public class Solution
{
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        // dp[i] = people aware of secret
        // dp[n] = dp[n-1] + new people - forget people
        // dp[n] = dp[n-1] + prev new people + curr new people - forget people
        // dp[0] = 0;
        // dp[1] = 1;
        int mod = (int)1e9 + 7;
        long[] dp = new long[n + 1];
        long[] add = new long[2 * n + 1];
        long[] sub = new long[2 * n + 1];
        dp[0] = 0;
        dp[1] = 1;
        add[delay + 1] = 1;
        sub[forget + 1] = 1;
        long canShare = 0;
        for (int i = 2; i <= n; i++)
        {
            canShare = (canShare + add[i] - sub[i]) % mod;
            dp[i] = ((dp[i - 1] - sub[i] + canShare) % mod + mod) % mod;
            add[i + delay] += canShare;
            sub[i + forget] += canShare;
        }

        return (int)dp[n];
    }
}