public class Solution
{
    public int MaximumSaleItems(int[][] items, int budget)
    {
        int n = items.Length;
        int[] count = new int[1501];
        for (int i = 0; i < n; i++)
        {
            int factor = items[i][0];
            for (int j = 1; j * j <= factor; j++)
            {
                if (factor % j == 0)
                {
                    count[j]++;
                    if (j * j != factor) count[factor / j]++;
                }
            }
        }
        // free = count[x] - 1
        int[,] dp = new int[n + 1, budget + 1];
        for (int i = 0; i <= budget; i++)
        {
            dp[0, i] = 0;
        }
        for (int i = 1; i <= n; i++)
        {
            int factor = items[i - 1][0];
            int cost = items[i - 1][1];
            for (int j = 0; j <= budget; j++)
            {
                dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
                if (j >= cost)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i, j - cost] + 1);
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - cost] + count[factor]);
                }
            }
        }
        int ans = 0;
        for (int i = 0; i <= budget; i++)
        {
            if (ans < dp[n, i]) ans = dp[n, i];
        }
        return ans;
    }
}
