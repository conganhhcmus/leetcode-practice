public class Solution
{
    public int NumSquares(int n)
    {
        int[] dp = new int[n + 1];
        // dp[i] least number of perfect square sum to i
        // dp[i] = min of dp[x] where x is equal i - square
        dp[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            dp[i] = i; // all sum of 1
            for (int j = 1; j * j <= i; j++)
            {
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
            }
        }

        return dp[n];
    }
}