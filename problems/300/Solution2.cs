#if DEBUG
namespace Problems_300_2;
#endif

public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        // dp[i] = save last element of LIS have length equal i;
        int len = 0;
        foreach (int num in nums)
        {
            int low = 0, high = len, ans = len;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (dp[mid] >= num)
                {
                    ans = mid;
                    high = mid - 1;
                }
                else low = mid + 1;
            }
            dp[ans] = num;
            if (ans == len) len++;
        }

        return len;
    }
}