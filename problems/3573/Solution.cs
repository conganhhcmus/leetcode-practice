public class Solution
{
    int[] prices;
    long[,,] memo;
    public long MaximumProfit(int[] prices, int k)
    {
        this.prices = prices;
        int n = prices.Length;
        memo = new long[n, k + 1, 3];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= k; j++)
            {
                for (int s = 0; s < 3; s++)
                {
                    memo[i, j, s] = -1;
                }
            }
        }
        return DP(n - 1, k, 0);
    }

    long DP(int i, int j, int state)
    {
        if (j == 0) return 0;
        if (i == 0)
        {
            return state == 0 ? 0 : (state == 1 ? -prices[0] : prices[0]);
        }
        long res = memo[i, j, state];
        if (res != -1) return res;
        int p = prices[i];
        if (state == 0)
        {
            res = Math.Max(DP(i - 1, j, 0), Math.Max(DP(i - 1, j, 1) + p, DP(i - 1, j, 2) - p));
        }
        else if (state == 1)
        {
            res = Math.Max(DP(i - 1, j, 1), DP(i - 1, j - 1, 0) - p);
        }
        else
        {
            res = Math.Max(DP(i - 1, j, 2), DP(i - 1, j - 1, 0) + p);
        }
        return memo[i, j, state] = res;
    }
}