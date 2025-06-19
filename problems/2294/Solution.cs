#if DEBUG
namespace Problems_2294;
#endif

public class Solution
{
    public int PartitionArray(int[] nums, int k)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int ret = 1;
        int min = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (nums[i] - min > k)
            {
                ret++;
                min = nums[i];
            }
        }
        return ret;
    }
}