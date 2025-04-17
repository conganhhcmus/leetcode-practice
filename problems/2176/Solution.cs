#if DEBUG
namespace Problems_2176;
#endif

public class Solution
{
    public int CountPairs(int[] nums, int k)
    {
        int n = nums.Length;
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[i] == nums[j] && i * j % k == 0) ret++;
            }
        }
        return ret;
    }
}