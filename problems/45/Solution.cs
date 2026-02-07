public class Solution
{
    public int Jump(int[] nums)
    {
        return Jump_Greedy(nums);
        // return Jump_DP(nums);
    }

    private int Jump_Greedy(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) return 0;
        int jumps = 0;
        int current = 0;
        int furthest = 0;
        for (int i = 0; i < n - 1; i++)
        {
            furthest = Math.Max(furthest, i + nums[i]);
            if (i == current)
            {
                jumps++;
                current = furthest;
                if (current >= n - 1) break;
            }
        }

        return jumps;
    }

    private int Jump_DP(int[] nums)
    {
        int[] dp = new int[nums.Length];
        Array.Fill(dp, nums.Length);
        dp[0] = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = 1; j <= nums[i] && (i + j) < nums.Length; j++)
            {
                dp[i + j] = Math.Min(dp[i + j], dp[i] + 1);
            }
        }
        return dp[nums.Length - 1];
    }
}