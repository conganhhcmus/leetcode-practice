namespace Problem_714;

using Helpers;
using Structures;
public class Solution
{
    public static void Execute()
    {
        int[] prices = [1, 3, 2, 8, 4, 9];
        int fee = 2;
        var solution = new Solution();
        Console.WriteLine(solution.MaxProfit(prices, fee));
    }
    public int MaxProfit(int[] prices, int fee)
    {
        return MaxProfit_DP(prices, fee);
    }

    public int MaxProfit_DP(int[] prices, int fee)
    {
        int[] dp = new int[2];
        for (int i = prices.Length - 1; i >= 0; i--)
        {
            dp[1] = Math.Max(-prices[i] + dp[0], dp[1]);
            dp[0] = Math.Max(prices[i] - fee + dp[1], dp[0]);
        }

        return dp[1];
    }

    public int MaxProfit_Greedy(int[] prices, int fee)
    {
        int n = prices.Length;
        int maxProfit = 0;
        int minPrice = prices[0];

        for (int i = 1; i < n; i++)
        {
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            else if (prices[i] > minPrice + fee)
            {
                maxProfit += prices[i] - minPrice - fee;
                minPrice = prices[i] - fee;
            }
        }

        return maxProfit;
    }
}