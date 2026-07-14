public class Solution
{
    public int SubsequencePairCount(int[] nums)
    {
        int n = nums.Length;
        int MAX = nums.Max();
        int MOD = 1_000_000_007;

        long[,,] dp = new long[n + 1, MAX + 1, MAX + 1];
        dp[0, 0, 0] = 1;
        for (int i = 1; i <= n; i++)
        {
            int x = nums[i - 1];
            for (int g1 = 0; g1 <= MAX; g1++)
            {
                for (int g2 = 0; g2 <= MAX; g2++)
                {
                    // skip x
                    dp[i, g1, g2] = (dp[i, g1, g2] + dp[i - 1, g1, g2]) % MOD;
                    // put x in A
                    int ng1 = GCD(x, g1);
                    dp[i, ng1, g2] = (dp[i, ng1, g2] + dp[i - 1, g1, g2]) % MOD;
                    // put x in B
                    int ng2 = GCD(x, g2);
                    dp[i, g1, ng2] = (dp[i, g1, ng2] + dp[i - 1, g1, g2]) % MOD;
                }
            }
        }
        long ans = 0L;
        for (int g = 1; g <= MAX; g++)
        {
            ans = (ans + dp[n, g, g]) % MOD;
        }
        return (int)ans;

        int GCD(int a, int b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }
            return a;
        }
    }
}
