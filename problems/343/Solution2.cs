#if DEBUG
namespace Problems_343_2;
#endif

public class Solution
{
    public int IntegerBreak(int n)
    {
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[n + 1];
            Array.Fill(dp[i], -1);
        }

        return DP(n, 0, dp);
    }

    int DP(int n, int k, int[][] dp)
    {
        if (n <= 0)
        {
            if (k >= 2) return 1;
            return 0;
        }
        if (dp[n][k] != -1) return dp[n][k];
        int ret = 0;
        for (int i = 1; i <= n; i++)
        {
            ret = Math.Max(ret, i * DP(n - i, k + 1, dp));
        }
        dp[n][k] = ret;
        return ret;
    }
}