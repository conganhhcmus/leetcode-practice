public class Solution
{
    public int SubsequencePairCount(int[] nums)
    {
        int n = nums.Length;
        int m = 0;
        int MOD = 1_000_000_007;
        for (int i = 0; i < n; i++) if (m < nums[i]) m = nums[i];
        long[,] dp = new long[m + 1, m + 1];
        dp[0, 0] = 1;
        for (int i = 0; i < n; i++)
        {
            long[,] ndp = new long[m + 1, m + 1];
            for (int g1 = 0; g1 <= m; g1++)
            {
                int dv1 = GCD(nums[i], g1);
                for (int g2 = 0; g2 <= m; g2++)
                {
                    int dv2 = GCD(nums[i], g2);
                    ndp[g1, g2] = (ndp[g1, g2] + dp[g1, g2]) % MOD;
                    ndp[dv1, g2] = (ndp[dv1, g2] + dp[g1, g2]) % MOD;
                    ndp[g1, dv2] = (ndp[g1, dv2] + dp[g1, g2]) % MOD;
                }
            }
            dp = ndp;
        }

        long ans = 0L;
        for (int g = 1; g <= m; g++)
        {
            ans = (ans + dp[g, g]) % MOD;
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
