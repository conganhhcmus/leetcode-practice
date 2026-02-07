public class Solution
{
    public int MaximumCount(int[] nums)
    {
        int n = nums.Length;
        // binary search right most less than zero
        int low = 0, high = n - 1, neg = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] < 0)
            {
                neg = mid;
                low = mid + 1;
            }
            else high = mid - 1;
        }

        // binary search left most greater than zero
        low = 0;
        high = n - 1;
        int pos = n;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] > 0)
            {
                pos = mid;
                high = mid - 1;
            }
            else low = mid + 1;
        }

        return Math.Max(neg + 1, n - pos);
    }
}