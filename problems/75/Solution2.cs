#if DEBUG
namespace Problems_75_2;
#endif

public class Solution
{
    public void SortColors(int[] nums)
    {
        int n = nums.Length;
        int left = 0, right = n - 1, i = 0;
        while (i <= right)
        {
            if (nums[i] == 0)
            {
                // swap with left
                (nums[i], nums[left]) = (nums[left], nums[i]);
                left++;
            }
            if (nums[i] == 2)
            {
                // swap with right
                (nums[i], nums[right]) = (nums[right], nums[i]);
                right--;
                i--;
            }
            i++;
        }
    }
}