#if DEBUG
namespace Problems_123_2;
#endif

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int profit1 = int.MinValue, profit2 = int.MinValue;
        int min1 = int.MaxValue, min2 = int.MaxValue;
        foreach (int price in prices)
        {
            min1 = Math.Min(min1, price);
            profit1 = Math.Max(profit1, price - min1);
            min2 = Math.Min(min2, price - profit1);
            profit2 = Math.Max(profit2, price - min2);
        }
        return profit2;
    }
}