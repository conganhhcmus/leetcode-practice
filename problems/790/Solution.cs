namespace Problem_790;

public class Solution
{
    public int NumTilings(int n)
    {
        int modulo = 1_000_000_007;
        int[] dp = new int[Math.Max(n, 2) + 1];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            dp[i] = (dp[i - 1] * 2 % modulo + dp[i - 3]) % modulo;
        }

        return dp[n];
    }
}