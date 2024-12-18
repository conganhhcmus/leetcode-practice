#if DEBUG
namespace Problems_1475;
#endif

public class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        int n = prices.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int j = i + 1;
            while (j < n && prices[j] > prices[i]) j++;
            if (j == n)
            {
                ans[i] = prices[i];
            }
            else
            {
                ans[i] = prices[i] - prices[j];
            }
        }

        return ans;
    }
}