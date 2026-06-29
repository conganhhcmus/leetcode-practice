public class Solution
{
    public long MaxSubarraySum(int[] nums, int k)
    {
        int n = nums.Length;
        long[][] dp = new long[n][];
        // dp[i][j] = maximum subarray ending at i with j state
        // j: 0 - normal, 1: mul, 2: div
        for (int i = 0; i < n; i++)
        {
            dp[i] = new long[3];
        }
        dp[0][0] = nums[0];
        dp[0][1] = 1L * k * nums[0];
        dp[0][2] = nums[0] / k;
        long max = dp[0].Max();
        for (int i = 1; i < n; i++)
        {
            dp[i][0] = Math.Max(nums[i], dp[i - 1][0] + nums[i]);

            dp[i][1] = Math.Max(1L * k * nums[i], dp[i - 1][1] + 1L * k * nums[i]);
            dp[i][1] = Math.Max(dp[i][1], dp[i - 1][0] + 1L * k * nums[i]);

            dp[i][2] = Math.Max(nums[i] / k, dp[i - 1][2] + (nums[i] / k));
            dp[i][2] = Math.Max(dp[i][2], dp[i - 1][0] + (nums[i] / k));

            if (max < dp[i].Max()) max = dp[i].Max();
            if (max < dp[i - 1][1] + nums[i]) max = dp[i - 1][1] + nums[i];
            if (max < dp[i - 1][2] + nums[i]) max = dp[i - 1][2] + nums[i];
        }
        return max;
    }
}
