#if DEBUG
namespace Problems_188_2;
#endif

public class Solution
{
    public int MaxProfit(int k, int[] prices)
    {
        int n = prices.Length;
        int[][] dp = new int[n + 1][];
        int[] min = new int[k + 1];
        Array.Fill(min, int.MaxValue);
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[k + 1];
        }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                // dp[i][j] = dp[i-1][j] // skip the current price
                // dp[i][j] = Max(dp[x][j-1] + prices[i-1] - prices[x]) 
                // = Max(dp[x][j-1] - prices[x]) + prices[i-1]
                // = prices[i-1] - Min(prices[x] - dp[x][j-1])
                min[j] = Math.Min(min[j], prices[i - 1] - dp[i - 1][j - 1]);
                dp[i][j] = Math.Max(dp[i - 1][j], prices[i - 1] - min[j]);
            }
        }
        return dp[n][k];
    }
}