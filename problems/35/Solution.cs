#if DEBUG
namespace Problems_35;
#endif

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int low = 0, high = nums.Length - 1, ans = nums.Length;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] >= target)
            {
                ans = mid;
                high = mid - 1;
            }
            else low = mid + 1;
        }
        return ans;
    }
}