public class Solution
{
    public int NumTilings(int n)
    {
        int mod = (int)1e9 + 7;
        int[] dp = new int[Math.Max(3, n + 1)];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;
        for (int i = 3; i <= n; i++)
        {
            dp[i] = (int)((2L * dp[i - 1] + dp[i - 3]) % mod);
        }
        return dp[n];
    }
}