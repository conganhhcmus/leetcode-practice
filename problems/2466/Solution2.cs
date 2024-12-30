#if DEBUG
namespace Problems_2466_2;
#endif

public class Solution
{
    public int CountGoodStrings(int low, int high, int zero, int one)
    {
        const int mod = 1_000_000_007;

        long[] dp = new long[high + 1];
        Array.Fill(dp, -1);
        dp[0] = 1;

        long DP(int end)
        {
            if (dp[end] != -1) return dp[end];
            long ans = 0;
            if (end >= zero)
            {
                ans += DP(end - zero);
            }
            if (end >= one)
            {
                ans += DP(end - one);
            }
            dp[end] = ans % mod;
            return dp[end];
        }

        long ans = 0;
        for (int i = low; i <= high; i++)
        {
            ans = (ans + DP(i)) % mod;
        }

        return (int)ans;
    }
}