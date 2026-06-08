public class Solution
{
    public long MaxTotal(int[] nums, string s)
    {
        int n = nums.Length;
        long[][] dp = new long[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new long[2];
        }
        // dp[i][0] = use at i and not move
        // dp[i][1] = move at i
        dp[0][0] = s[0] == '1' ? nums[0] : 0;
        dp[0][1] = s[0] == '1' ? long.MinValue / 3 : 0;
        for (int i = 1; i < n; i++)
        {
            if (s[i] == '1')
            {
                // use it
                dp[i][0] = Math.Max(dp[i][0], dp[i - 1][0] + nums[i]);
                dp[i][0] = Math.Max(dp[i][0], dp[i - 1][1] + nums[i]);
                // move it
                dp[i][1] = Math.Max(dp[i][1], nums[i - 1] + dp[i - 1][1]);
                if (s[i - 1] == '0') dp[i][1] = Math.Max(dp[i][1], nums[i - 1] + dp[i - 1][0]);
            }
            else
            {
                dp[i][0] = dp[i][1] = Math.Max(dp[i - 1][0], dp[i - 1][1]);
            }
        }

        return Math.Max(dp[n - 1][0], dp[n - 1][1]);
    }
}
