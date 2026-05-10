public class Solution
{
    public int MaximumJumps(int[] nums, int target)
    {
        // jump to right if |nums[r] - nums[l]| <= target
        int n = nums.Length;
        int[] dp = new int[n];
        Array.Fill(dp, -1);
        dp[n - 1] = 0;
        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = n - 1; j > i; j--)
            {
                if (dp[j] < 0 || Math.Abs(nums[i] - nums[j]) > target) continue;
                dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }

        return dp[0];
    }
}
