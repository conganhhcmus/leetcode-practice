public class Solution
{
    int INF = int.MaxValue / 2;
    public int MinCost(int n)
    {
        int[] dp = new int[n + 1];
        Array.Fill(dp, INF);
        dp[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            dp[i] = Math.Min(dp[i], dp[i - 1] + i - 1);
            for (int j = 2; j <= i / 2; j++)
            {
                dp[i] = Math.Min(dp[i], j * (i - j) + dp[j] + dp[i - j]);
            }
        }

        return dp[n];
    }
}