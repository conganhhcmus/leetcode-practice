#if DEBUG
namespace Problems_300;
#endif

public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        // dp[i] = length of LIS ending with i;
        // dp[i] = max(dp[k], dp[i]) where arr[i]>arr[k];
        int[] dp = new int[n + 1];
        Array.Fill(dp, 1);
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j < i; j++)
            {
                if (nums[i - 1] > nums[j - 1])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        int max = 0;
        for (int i = 0; i <= n; i++)
        {
            max = Math.Max(max, dp[i]);
        }
        return max;
    }
}