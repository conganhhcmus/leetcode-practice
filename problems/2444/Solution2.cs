#if DEBUG
namespace Problems_2444_2;
#endif

public class Solution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        long ret = 0;
        int n = nums.Length;
        int lastMin = -1, lastMax = -1, lastInvalid = -1;
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            if (num == minK) lastMin = i;
            if (num == maxK) lastMax = i;
            if (num < minK || num > maxK) lastInvalid = i;
            ret += int.Max(0, int.Min(lastMax, lastMin) - lastInvalid);
        }

        return ret;
    }
}