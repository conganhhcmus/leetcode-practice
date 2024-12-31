#if DEBUG
namespace Problems_983;
#endif

public class Solution
{
    public int MincostTickets(int[] days, int[] costs)
    {
        // dp[i] = min(dp[i-1] + costs[0], dp[i-7] + costs[1], dp[i-30] + costs[2])
        int lastDay = days[^1];
        int[] dp = new int[lastDay + 1];
        int i = 0;
        for (int day = 1; day <= lastDay; day++)
        {
            if (day < days[i])
            {
                dp[day] = dp[day - 1];
            }
            else
            {
                i++;
                int cost1 = costs[0] + dp[Math.Max(0, day - 1)];
                int cost7 = costs[1] + dp[Math.Max(0, day - 7)];
                int cost30 = costs[2] + dp[Math.Max(0, day - 30)];
                dp[day] = Math.Min(cost1, Math.Min(cost7, cost30));
            }
        }

        return dp[lastDay];
    }
}