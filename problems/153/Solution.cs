public class Solution
{
    public int FindMin(int[] nums)
    {
        int n = nums.Length;
        int low = 0, high = n - 1, ans = int.MaxValue;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] >= nums[low])// [low-mid] is sorted
            {
                ans = Math.Min(ans, nums[low]);
                low = mid + 1;
            }
            else // [mid - high] is sorted
            {
                ans = Math.Min(ans, nums[mid]);
                high = mid - 1;
            }
        }

        return ans;
    }
}