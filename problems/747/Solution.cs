#if DEBUG
namespace Problems_747;
#endif

public class Solution
{
    public int DominantIndex(int[] nums)
    {
        int maxIdx = 0;
        int n = nums.Length;
        for (int i = 1; i < n; ++i)
        {
            if (nums[i] > nums[maxIdx]) maxIdx = i;
        }
        for (int i = 0; i < n; ++i)
        {
            if (i != maxIdx && 2 * nums[i] > nums[maxIdx]) return -1;
        }
        return maxIdx;
    }
}