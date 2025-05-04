#if DEBUG
namespace Problems_309_3;
#endif

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        // dp[i][j] = max profit at i-th day and j is 0: buy, 1: sell
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[2];
        }

        dp[1][0] = -prices[0];
        for (int i = 2; i <= n; i++)
        {
            dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] + prices[i - 1]);
            dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 2][1] - prices[i - 1]);
        }

        return dp[n][1];
    }
}