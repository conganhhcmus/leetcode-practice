public class Solution
{
    public double MinPrice(int[] prices, int[] discounts)
    {
        Array.Sort(prices, (a, b) => b.CompareTo(a));
        Array.Sort(discounts, (a, b) => b.CompareTo(a));
        int n = prices.Length, m = discounts.Length;
        int i = 0, j = 0;
        double tot = 0.0;
        while (i < n && j < m)
        {
            tot += 1.0 * prices[i] * (100 - discounts[j]) / 100;
            i++;
            j++;
        }
        while (i < n)
        {
            tot += prices[i];
            i++;
        }
        return tot;
    }
}
