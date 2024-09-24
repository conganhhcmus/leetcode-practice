namespace Problem_122;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] prices = [1, 2, 3, 4, 6];
        Console.WriteLine(solution.MaxProfit(prices));
    }
    public int MaxProfit(int[] prices)
    {
        int buy = prices[0];
        int profit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            if ((prices[i] - buy) > 0)
            {
                profit += prices[i] - buy;
            }
            buy = prices[i];
        }
        return profit;
    }
}