#if DEBUG
namespace Problems_3637_3;
#endif

public class Solution
{
    public bool IsTrionic(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        if (nums[0] >= nums[1]) return false;
        for (int i = 2; i < n; i++)
        {
            if (nums[i] == nums[i - 1]) return false;
            if ((nums[i - 2] - nums[i - 1]) * (nums[i - 1] - nums[i]) < 0) count++;
        }
        return count == 2;
    }
}