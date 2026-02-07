public class Solution
{
    public int Search(int[] nums, int target)
    {
        int n = nums.Length;
        int low = 0, high = n - 1, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target)
            {
                ans = mid;
                break;
            }
            else if (nums[mid] >= nums[low])
            {
                if (nums[low] <= target && target <= nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            else
            {
                if (nums[mid] <= target && target <= nums[high])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

        }
        return ans;
    }
}