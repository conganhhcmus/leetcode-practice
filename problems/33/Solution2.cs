public class Solution
{
    public int Search(int[] nums, int target)
    {
        int n = nums.Length;
        int low = 0, high = n - 1, k = n - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] >= nums[0] && nums[mid] >= nums[n - 1])
            {
                k = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        low = 0;
        high = k;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target) return mid;
            if (nums[mid] > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        low = k + 1;
        high = n - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target) return mid;
            if (nums[mid] > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return -1;
    }
}
