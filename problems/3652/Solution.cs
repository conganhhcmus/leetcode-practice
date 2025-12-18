#if DEBUG
namespace Problems_3652;
#endif

public class Solution
{
    public long MaxProfit(int[] prices, int[] strategy, int k)
    {
        long ans = long.MinValue;
        int n = prices.Length;
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += 1L * prices[i] * strategy[i];
        }
        ans = Math.Max(ans, sum);
        for (int i = 0; i < k / 2; i++)
        {
            sum += 0L * prices[i] - 1L * strategy[i] * prices[i];
        }
        for (int i = k / 2; i < k; i++)
        {
            sum += 1L * prices[i] - 1L * strategy[i] * prices[i];
        }
        ans = Math.Max(ans, sum);

        for (int i = k; i < n; i++)
        {
            // a half of k
            sum += 1L * prices[i] - 1L * strategy[i] * prices[i];
            sum += -1L * prices[i - k / 2] + 1L * strategy[i - k / 2] * prices[i - k / 2];
            // remain of k
            sum += 0L * prices[i - k / 2] - 1L * strategy[i - k / 2] * prices[i - k / 2];
            sum += -0L * prices[i - k] + 1L * strategy[i - k] * prices[i - k];
            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}