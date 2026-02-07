public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        int n = prices.Length;
        long[] dp = new long[n];
        dp[0] = 1;
        int prev = 0;
        for (int i = 1; i < n; i++)
        {
            dp[i] = dp[i - 1] + 1;
            if (prices[i - 1] - prices[i] == 1)
            {
                dp[i] += i - prev;
            }
            else
            {
                prev = i;
            }
        }
        return dp[n - 1];
    }
}