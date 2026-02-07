public class Solution
{
    public int WiggleMaxLength(int[] nums)
    {
        int n = nums.Length;
        Pair[] dp = new Pair[n];
        dp[0] = new(1, 1);
        for (int i = 1; i < n; i++)
        {
            var prev = dp[i - 1];
            if (nums[i] == nums[i - 1])
            {
                dp[i] = new(prev.Up, prev.Down);
            }
            else if (nums[i] > nums[i - 1])
            {
                dp[i] = new(Math.Max(prev.Up, prev.Down + 1), prev.Down);
            }
            else
            {
                dp[i] = new(prev.Up, Math.Max(prev.Down, prev.Up + 1));
            }
        }

        return Math.Max(dp[n - 1].Up, dp[n - 1].Down);
    }

    public record Pair(int Up, int Down);
}