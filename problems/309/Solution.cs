#if DEBUG
namespace Problems_309;
#endif

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        // n = 5000
        // dp[i][j] where i is i-th day and j = 0:none, 1: buy, 2: sell
        int n = prices.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[3];
            Array.Fill(dp[i], -1);
        }
        int ret = 0;
        for (int i = 0; i < 3; i++)
        {
            ret = Math.Max(ret, DP(n - 1, i, prices, dp));
        }

        return ret;
    }

    int DP(int day, int state, int[] prices, int[][] dp)
    {
        if (day <= 0) return 0;
        if (dp[day][state] != -1) return dp[day][state];
        int ret = 0;
        if (state == 0) // none
        {
            for (int i = 0; i < day; i++)
            {
                ret = Math.Max(ret, DP(i, 2, prices, dp));
            }
        }
        else if (state == 1) // buy
        {
            for (int i = 0; i < day - 1; i++)
            {
                ret = Math.Max(ret, DP(i, 2, prices, dp));
            }
        }
        else // sell
        {
            for (int i = 0; i < day; i++)
            {
                ret = Math.Max(ret, DP(i, 1, prices, dp) + prices[day] - prices[i]);
            }
        }

        dp[day][state] = ret;
        return ret;
    }
}