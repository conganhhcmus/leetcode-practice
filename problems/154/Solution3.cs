
public class Solution
{
    public int FindMin(int[] nums)
    {
        int n = nums.Length;
        int low = 0, high = n - 1;
        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] < nums[high])
            {
                high = mid;
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
        return nums[low];
    }
}
