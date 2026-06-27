public class Solution
{
    public long MaximumScore(int[] nums, int k)
    {
        int n = nums.Length;
        long INF = 1L << 60;
        long[] sufMax = new long[n];
        long[] sufMin = new long[n];
        sufMax[n - 1] = nums[n - 1];
        sufMin[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            sufMax[i] = Math.Max(sufMax[i + 1], nums[i]);
            sufMin[i] = Math.Min(sufMin[i + 1], nums[i]);
        }
        long ans = 0L;

        long[,,] dp = new long[n + 1, 2 * k + 1, 2];
        for (int iter = 0; iter < 3; iter++)
        {
            // iter: 0-normal, 1: missing max, 2: missing min
            // init
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= 2 * k; j++)
                {
                    dp[i, j, 0] = -INF;
                    dp[i, j, 1] = -INF;
                }
            }
            if (iter != 2) dp[0, 0, 0] = 0;
            if (iter != 1) dp[0, 0, 1] = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= 2 * k; j++)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        if (dp[i, j, x] == -INF) continue;
                        // skip
                        dp[i + 1, j, x] = Math.Max(dp[i + 1, j, x], dp[i, j, x]);

                        if (j == 2 * k) continue;
                        long v = (x == 1) ? nums[i] : -nums[i];
                        if (iter == 0)
                        {
                            // alter sign
                            dp[i + 1, j + 1, x ^ 1] = Math.Max(dp[i + 1, j + 1, x ^ 1], dp[i, j, x] + v);
                            if (((j + 1) & 1) == 0)
                            {
                                dp[i + 1, j + 1, x] = Math.Max(dp[i + 1, j + 1, x], dp[i, j, x] + v);
                                ans = Math.Max(ans, dp[i, j, x] + v);
                            }
                        }
                        else if (iter == 1)
                        {
                            if (((j + 1) & 1) == 0)
                            {
                                ans = Math.Max(ans, dp[i, j, x] + sufMax[i]);
                            }
                            if (j < 2 * k - 1)
                            {
                                dp[i + 1, j + 1, x ^ 1] = Math.Max(dp[i + 1, j + 1, x ^ 1], dp[i, j, x] + v);
                                if (((j + 1) & 1) == 1)
                                {
                                    dp[i + 1, j + 1, x] = Math.Max(dp[i + 1, j + 1, x], dp[i, j, x] + v);
                                }
                            }
                        }
                        else
                        {
                            if (((j + 1) & 1) == 0)
                            {
                                ans = Math.Max(ans, dp[i, j, 1] - sufMin[i]);
                            }
                            if (j < 2 * k - 1)
                            {
                                dp[i + 1, j + 1, x ^ 1] = Math.Max(dp[i + 1, j + 1, x ^ 1], dp[i, j, x] + v);
                                if (((j + 1) & 1) == 1)
                                {
                                    dp[i + 1, j + 1, x] = Math.Max(dp[i + 1, j + 1, x], dp[i, j, x] + v);
                                }
                            }
                        }
                    }
                }
            }
        }
        return ans;
    }
}
