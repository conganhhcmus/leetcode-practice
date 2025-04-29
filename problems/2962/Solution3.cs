#if DEBUG
namespace Problems_2962_3;
#endif

public class Solution
{
    public long CountSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        int max = 0;
        foreach (int num in nums)
        {
            if (max < num) max = num;
        }
        List<int> indexList = [];
        long ret = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == max) indexList.Add(i);
            if (indexList.Count >= k)
            {
                ret += indexList[^k] + 1;
            }
        }
        return ret;
    }
}