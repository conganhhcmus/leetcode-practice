namespace Problem_198;
public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[1], dp[0]);

        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return dp[^1];
    }
}