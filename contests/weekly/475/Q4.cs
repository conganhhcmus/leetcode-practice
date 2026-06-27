public class Solution
{
    public long MaximumScore(int[] nums, int k)
    {
        long INF = 1L << 60;
        long ans = 0L;

        // 0: have 1 min, 1: balance, 2: have 1 max
        for (int start = 0; start < 3; start++)
        {
            long[][] dp = new long[2 * k + 1][];
            for (int i = 0; i <= 2 * k; i++)
            {
                dp[i] = new long[3];
                Array.Fill(dp[i], -INF);
            }

            dp[0][start] = 0;
            foreach (int num in nums)
            {
                // backward interation (0/1 knapsack style)
                for (int cnt = 2 * k - 1; cnt >= 0; cnt--)
                {
                    for (int state = 0; state < 3; state++)
                    {
                        if (dp[cnt][state] == -INF) continue;
                        // choose this number as a maxium (+num)
                        if (state < 2)
                        {
                            dp[cnt + 1][state + 1] = Math.Max(dp[cnt + 1][state + 1], dp[cnt][state] + num);
                        }

                        // choose this number as a minimum (-num)
                        if (state > 0)
                        {
                            dp[cnt + 1][state - 1] = Math.Max(dp[cnt + 1][state - 1], dp[cnt][state] - num);
                        }
                    }
                }
            }
            for (int cnt = 0; cnt <= 2 * k; cnt++)
            {
                ans = Math.Max(ans, dp[cnt][start]);
            }
        }
        return ans;
    }
}
