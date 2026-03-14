public class Solution
{
    public int RearrangeSticks(int n, int k)
    {
        int mod = (int)1e9 + 7;
        long[][] dp = new long[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new long[k + 1];
        }
        // dp[n][k] : number of ways to arrange n sticks with exactly k visible
        // case1: add 1 at first => dp[n][k] = dp[n-1][k-1]
        // case2: add 1 at other position => dp[n][k] = dp[n-1][k] * (n-1)
        dp[0][0] = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                dp[i][j] = (dp[i - 1][j - 1] + 1L * (i - 1) * dp[i - 1][j]) % mod;
            }
        }

        return (int)dp[n][k];
    }
}