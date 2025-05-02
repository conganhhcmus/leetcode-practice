#if DEBUG
namespace Problems_2008;
#endif

public class Solution
{
    public long MaxTaxiEarnings(int n, int[][] rides)
    {
        // n = 10^5
        // rides.Length = 3*10^4
        // sort rides by end
        // dp[i] = max taxi earning with end at i
        Array.Sort(rides, (a, b) => a[1] - b[1]);
        long[] dp = new long[n + 1];
        int prev = 0;
        foreach (int[] ride in rides)
        {
            int start = ride[0], end = ride[1], tips = ride[2];
            for (int i = prev + 1; i <= end; i++)
            {
                dp[i] = Math.Max(dp[i], dp[i - 1]);
            }
            prev = end;
            dp[end] = Math.Max(dp[end], dp[start] + end - start + tips);
        }

        for (int i = prev + 1; i <= n; i++)
        {
            dp[i] = Math.Max(dp[i], dp[i - 1]);
        }

        return dp[n];
    }
}