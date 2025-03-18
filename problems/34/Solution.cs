#if DEBUG
namespace Problems_34;
#endif

public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        int[] ret = [-1, -1];
        int n = nums.Length;
        int low = 0, high = n - 1, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target)
            {
                ans = mid;
                high = mid - 1;
            }
            else if (nums[mid] > target)
            {
                high = mid - 1;
            }
            else low = mid + 1;
        }

        if (ans == -1) return ret;
        ret[0] = ans;
        low = 0;
        high = n - 1;
        ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target)
            {
                ans = mid;
                low = mid + 1;
            }
            else if (nums[mid] < target)
            {
                low = mid + 1;
            }
            else high = mid - 1;
        }
        ret[1] = ans;
        return ret;
    }
}