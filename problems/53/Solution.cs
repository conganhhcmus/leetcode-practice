public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        dp[0] = nums[0];
        // dp[i] stores the maximum sum of a subArray ending at index i (from 0 to i)
        int ans = dp[0];
        for (int i = 1; i < n; i++)
        {
            dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);
            // update ans
            ans = Math.Max(ans, dp[i]);
        }
        return ans;
    }
}