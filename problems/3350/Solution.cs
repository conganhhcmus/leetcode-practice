#if DEBUG
namespace Problems_3350;
#endif

public class Solution
{
    public int MaxIncreasingSubarrays(IList<int> nums)
    {
        int n = nums.Count;
        int[] dp = new int[n];
        dp[0] = 1;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                dp[i] = dp[i - 1] + 1;
            }
            else
            {
                dp[i] = 1;
            }
        }
        int low = 1, high = n / 2, ans = 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(dp, mid))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }

    bool Ok(int[] dp, int k)
    {
        int n = dp.Length;
        for (int i = 2 * k - 1; i < n; i++)
        {
            if (dp[i] >= k && dp[i - k] >= k) return true;
        }
        return false;
    }
}