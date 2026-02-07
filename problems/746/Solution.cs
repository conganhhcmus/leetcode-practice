public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int[] dp = new int[cost.Length];
        for (int i = 2; i < cost.Length; i++)
        {
            dp[i] = Math.Min(cost[i - 1] + dp[i - 1], cost[i - 2] + dp[i - 2]);
        }
        return Math.Min(dp[^2] + cost[^2], dp[^1] + cost[^1]);
    }
}