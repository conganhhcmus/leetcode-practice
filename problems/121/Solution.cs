namespace Problem_121;
public class Solution
{
    public static void Execute()
    {
        int[] prices = [7, 1, 5, 3, 6, 4];
        var solution = new Solution();
        Console.WriteLine(solution.MaxProfit(prices));
    }
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