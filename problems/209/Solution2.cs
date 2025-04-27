#if DEBUG
namespace Problems_209_2;
#endif

public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int low = 1, high = nums.Length, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(nums, target, mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ans;
    }
    bool Ok(int[] nums, int target, int len)
    {
        long sum = 0;
        for (int i = 0; i < len; i++)
        {
            sum += nums[i];
        }
        if (sum >= target) return true;
        for (int i = len; i < nums.Length; i++)
        {
            sum += nums[i] - nums[i - len];
            if (sum >= target) return true;
        }
        return false;
    }
}