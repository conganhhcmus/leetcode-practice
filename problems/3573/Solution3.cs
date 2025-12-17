#if DEBUG
namespace Problems_3573_3;
#endif

public class Solution
{
    public long MaximumProfit(int[] prices, int k)
    {
        int n = prices.Length;
        long[,] dp = new long[k + 1, 3];
        for (int j = 1; j <= k; j++)
        {
            dp[j, 1] = -prices[0];
            dp[j, 2] = prices[0];
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = k; j > 0; j--)
            {
                dp[j, 0] = Math.Max(dp[j, 0], Math.Max(dp[j, 1] + prices[i], dp[j, 2] - prices[i]));
                dp[j, 1] = Math.Max(dp[j, 1], dp[j - 1, 0] - prices[i]);
                dp[j, 2] = Math.Max(dp[j, 2], dp[j - 1, 0] + prices[i]);
            }
        }

        return dp[k, 0];
    }
}