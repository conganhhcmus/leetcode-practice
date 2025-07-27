#if DEBUG
namespace Problems_2210_2;
#endif

public class Solution
{
    public int CountHillValley(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        int left = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if (nums[i] != nums[i + 1])
            {
                if ((nums[left] > nums[i] && nums[i] < nums[i + 1]) ||
                    (nums[left] < nums[i] && nums[i] > nums[i + 1]))
                {
                    count++;
                }
                left = i;
            }
        }
        return count;
    }
}