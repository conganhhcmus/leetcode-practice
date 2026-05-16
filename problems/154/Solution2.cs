public class Solution
{
    public int FindMin(int[] nums)
    {
        int n = nums.Length;
        int low = 0, high = n - 1, ans = nums[0];
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (ans > nums[mid]) ans = nums[mid];
            if (nums[mid] < nums[high])
            {
                high = mid - 1;
            }
            else if (nums[mid] > nums[high])
            {
                low = mid + 1;
            }
            else
            {
                high--;
            }
        }
        return ans;
    }
}
