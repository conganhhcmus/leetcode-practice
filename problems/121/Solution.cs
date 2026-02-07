public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int max = 0;
        int min = prices[0];
        for (int i = 0; i < prices.Length; i++)
        {
            min = Math.Min(min, prices[i]);
            max = Math.Max(max, prices[i] - min);
        }

        return max;
    }
}