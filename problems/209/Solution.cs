#if DEBUG
namespace Problems_209;
#endif

public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int n = nums.Length;
        int left = 0, right = 0;
        long sum = 0;
        int ans = int.MaxValue;
        while (right < n)
        {
            sum += nums[right];
            while (left < right && sum - nums[left] >= target)
            {
                sum -= nums[left];
                left++;
            }
            if (sum >= target) ans = Math.Min(ans, right - left + 1);
            right++;
        }
        return (ans == int.MaxValue) ? 0 : ans;
    }
}