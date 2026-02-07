public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        int n = nums.Length;
        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int s = 1; s <= target; s++)
        {
            for (int i = 0; i < n; i++)
            {
                if (s >= nums[i])
                {
                    dp[s] += dp[s - nums[i]];
                }
            }
        }

        return dp[target];
    }
}