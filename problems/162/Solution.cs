#if DEBUG
namespace Problems_162;
#endif

public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        int n = nums.Length;
        int low = 0, high = n - 1, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if ((mid == 0 || nums[mid] > nums[mid - 1]) && (mid == n - 1 || nums[mid] > nums[mid + 1]))
            {
                ans = mid;
                break;
            }
            else if (mid == 0 || nums[mid] > nums[mid - 1])
            {
                low = mid + 1;
            }
            else high = mid - 1;
        }

        return ans;
    }
}