#if DEBUG
namespace Problems_485;
#endif

public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int max = 0;
        int n = nums.Length;
        int j = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                max = Math.Max(max, i - 1 - j);
                j = i;
            }
        }
        max = Math.Max(max, n - 1 - j);
        return max;
    }
}