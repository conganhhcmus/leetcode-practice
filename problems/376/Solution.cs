#if DEBUG
namespace Problems_376;
#endif

public class Solution
{
    public int WiggleMaxLength(int[] nums)
    {
        // dp[i][j] = max length of wiggle subsequence end at i and j is state 0: greater, 1: less
        // dp[i][j] = max length of (dp[x][1-j] and nums[i] vs nums[x]) where x from 0 to i
        int n = nums.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[2];
        }
        dp[0][0] = dp[0][1] = 1;
        int ret = 1;

        for (int i = 1; i < n; i++)
        {
            dp[i][0] = dp[i][1] = 1;
            for (int x = 0; x < i; x++)
            {
                if (nums[i] == nums[x]) continue;
                if (nums[i] > nums[x])
                {
                    dp[i][0] = Math.Max(dp[i][0], 1 + dp[x][1]);
                }
                else
                {
                    dp[i][1] = Math.Max(dp[i][1], 1 + dp[x][0]);
                }
            }
            ret = Math.Max(ret, Math.Max(dp[i][0], dp[i][1]));
        }

        return ret;
    }
}