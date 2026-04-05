public class Solution
{
    public long MinIncrease(int[] nums)
    {
        int n = nums.Length;
        long INF = long.MaxValue / 2;
        long[][] dp = new long[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = [0, INF];
        }

        dp[0] = [0, 0];
        for (int i = 1; i < n; i++)
        {
            dp[i][0] = dp[i - 1][0];
            dp[i][1] = dp[i - 1][1];
            if (i > 1)
            {
                long val = Math.Max(nums[i - 2], nums[i]) + 1;
                long need = Math.Max(0, val - nums[i - 1]);
                long cnt = dp[i - 2][0] + 1;
                long tot = dp[i - 2][1] + need;
                if (cnt == dp[i][0])
                {
                    dp[i][1] = Math.Min(dp[i][1], tot);
                }
                else if (cnt > dp[i][0])
                {
                    dp[i][0] = cnt;
                    dp[i][1] = tot;
                }
            }
        }
        return dp[n - 1][1];
    }
}