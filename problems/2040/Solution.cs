#if DEBUG
namespace Problems_2040;
#endif

public class Solution
{
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
    {
        int n1 = nums1.Length;
        long low = -10000000000L, high = 10000000000L, ans = 0;
        while (low <= high)
        {
            long mid = low + (high - low) / 2;
            long count = 0;
            for (int i = 0; i < n1; i++)
            {
                count += Count(nums2, nums1[i], mid);
            }

            if (count >= k)
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

    long Count(int[] nums, int val, long target)
    {
        int n = nums.Length;
        int low = 0, high = n - 1, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            long prod = 1L * nums[mid] * val;
            if ((val >= 0 && prod <= target) || (val < 0 && prod > target))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        if (val >= 0) return ans + 1;
        return n - ans - 1;
    }
}