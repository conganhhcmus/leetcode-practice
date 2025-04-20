#if DEBUG
namespace Weekly_446_Q2;
#endif

public class Solution
{
    public int MaximumPossibleSize(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        int prev = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] >= prev)
            {
                count++;
                prev = nums[i];
            }
        }

        return count;
    }
}