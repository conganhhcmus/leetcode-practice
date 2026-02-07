public class Solution
{
    public bool ValidPartition(int[] nums)
    {
        int n = nums.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true;
        dp[1] = false; // default
        dp[2] = nums[0] == nums[1];
        for (int i = 3; i <= n; i++)
        {
            if (dp[i - 2] && (nums[i - 1] == nums[i - 2]))
            {
                dp[i] = true;
                continue;
            }
            if (dp[i - 3] && (nums[i - 1] == nums[i - 2]) && (nums[i - 1] == nums[i - 3]))
            {
                dp[i] = true;
                continue;
            }
            if (dp[i - 3] && (nums[i - 1] == nums[i - 2] + 1) && (nums[i - 1] == nums[i - 3] + 2))
            {
                dp[i] = true;
                continue;
            }
        }

        return dp[n];
    }
}