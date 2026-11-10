public class Solution
{
    public int ClimbStairs(int n, int[] costs)
    {
        int[] dp = new int[n + 1];
        int INF = 1 << 30;
        Array.Fill(dp, INF);
        dp[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                if (i - j < 0) break;
                // jump from i - j to i
                dp[i] = Math.Min(dp[i], dp[i - j] + costs[i - 1] + j * j);
            }
        }

        return dp[n];
    }
}