#if DEBUG
namespace Problems_2779;
#endif

public class Solution
{
    public int MaximumBeauty(int[] nums, int k)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int maxBeauty = 0;
        int left = 0;
        for (int right = 0; right < n; right++)
        {
            while (nums[right] - nums[left] > 2 * k && left < right)
            {
                left++;
            }
            maxBeauty = Math.Max(maxBeauty, right - left + 1);
        }
        return maxBeauty;
    }
}