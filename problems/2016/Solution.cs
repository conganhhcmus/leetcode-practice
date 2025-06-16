#if DEBUG
namespace Problems_2016;
#endif

public class Solution
{
    public int MaximumDifference(int[] nums)
    {
        int n = nums.Length;
        int ret = -1;
        int min = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > min) ret = Math.Max(ret, nums[i] - min);
            else min = nums[i];
        }
        return ret;
    }
}