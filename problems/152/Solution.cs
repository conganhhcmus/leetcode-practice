#if DEBUG
namespace Problems_152;
#endif

public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int n = nums.Length;
        int[][] dp = new int[n][];
        // dp[i] = maxProduct end with i
        // nums[i] >= 0 dp[i] = maxProduct end with i-1 *nums[i]
        // nums[i] < 0 dp[i] = minProduct end with i-1 * nums[i]
        dp[0] = [nums[0], nums[0]];
        int max = dp[0][0];
        for (int i = 1; i < n; i++)
        {
            dp[i] = new int[2];
            dp[i][0] = Math.Max(nums[i], Math.Max(dp[i - 1][0] * nums[i], dp[i - 1][1] * nums[i]));
            dp[i][1] = Math.Min(nums[i], Math.Min(dp[i - 1][0] * nums[i], dp[i - 1][1] * nums[i]));
            max = Math.Max(max, dp[i][0]);
        }
        return max;
    }
}