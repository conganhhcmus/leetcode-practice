#if DEBUG
namespace Problems_309_2;
#endif

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        // dp[i][j] = max profit at i-th day and j one of 0: none, 1: buy, 2: sell
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[3];
        }

        int max = -prices[0];
        for (int i = 2; i <= n; i++)
        {
            dp[i][0] = dp[i - 1].Max();
            dp[i][1] = Math.Max(dp[i - 2][2], dp[i - 1][0]);
            dp[i][2] = max + prices[i - 1];
            max = Math.Max(max, dp[i][1] - prices[i - 1]);
        }

        return dp[n].Max();
    }
}