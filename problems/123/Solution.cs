public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        int k = 2;
        int[][][] memo = new int[n][][];
        for (int i = 0; i < n; i++)
        {
            memo[i] = new int[k + 1][];
            for (int j = 0; j <= k; j++)
            {
                memo[i][j] = [-1, -1];
            }
        }
        return DP(prices, 0, k, 0, memo);
    }

    int DP(int[] prices, int pos, int k, int bought, int[][][] memo)
    {
        if (pos >= prices.Length || k == 0) return 0;
        if (memo[pos][k][bought] != -1) return memo[pos][k][bought];
        int ans = DP(prices, pos + 1, k, bought, memo); // skip
        if (bought == 1)
        {
            ans = Math.Max(ans, DP(prices, pos + 1, k - 1, 0, memo) + prices[pos]); // sell
        }
        else
        {
            ans = Math.Max(ans, DP(prices, pos + 1, k, 1, memo) - prices[pos]); // bought
        }

        memo[pos][k][bought] = ans;
        return ans;
    }
}