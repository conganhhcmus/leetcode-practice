#if DEBUG
namespace Problems_3068_4;
#endif

public class Solution
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long[] dp = [0, long.MinValue];
        foreach (int num in nums)
        {
            long[] dp2 = [dp[0] + num, dp[1] + num];
            dp2[1] = Math.Max(dp2[1], dp[0] + (num ^ k));
            dp2[0] = Math.Max(dp2[0], dp[1] + (num ^ k));
            dp = dp2;
        }
        return dp[0];
    }
}