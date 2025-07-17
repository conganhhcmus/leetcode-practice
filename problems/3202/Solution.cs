#if DEBUG
namespace Problems_3202;
#endif

public class Solution
{
    public int MaximumLength(int[] nums, int k)
    {
        int n = nums.Length;
        int ans = 0;
        for (int val = 0; val < k; val++)
        {
            int[] dp = new int[k];
            for (int i = 0; i < n; i++)
            {
                int m = nums[i] % k;
                int want = (val - m + k) % k;
                dp[m] = Math.Max(dp[m], dp[want] + 1);
                ans = Math.Max(ans, dp[m]);
            }
        }

        return ans;
    }
}