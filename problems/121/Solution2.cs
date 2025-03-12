#if DEBUG
namespace Problems_121_2;
#endif

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        // f[0] = 0
        // f[i] = f[i-1] + Max(0, prices[i]-prices[i-1])
        int n = prices.Length;
        int[] f = new int[n];
        f[0] = 0;
        int max = 0;
        for (int i = 1; i < n; i++)
        {
            f[i] = Math.Max(0, f[i - 1] + prices[i] - prices[i - 1]);
            max = Math.Max(max, f[i]);
        }
        return max;
    }
}