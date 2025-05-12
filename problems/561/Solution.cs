#if DEBUG
namespace Problems_561;
#endif

public class Solution
{
    public int ArrayPairSum(int[] nums)
    {
        int ret = 0;
        Array.Sort(nums);
        int n = nums.Length / 2;
        for (int i = 0; i < n; i++)
        {
            ret += nums[2 * i];
        }
        return ret;
    }
}