#if DEBUG
namespace Problems_2579;
#endif

public class Solution
{
    public long ColoredCells(int n)
    {
        long[] dp = new long[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i - 1] + (i - 1) * 4L;
        }

        return dp[n];
    }
}