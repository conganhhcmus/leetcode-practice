#if DEBUG
namespace Biweekly_151_Q1;
#endif

public class Solution
{
    public int[] TransformArray(int[] nums)
    {
        int countOdd = 0;
        foreach (int num in nums) countOdd += (num & 1);
        int[] ans = new int[nums.Length];
        for (int i = 1; i <= countOdd; i++)
        {
            ans[^i] = 1;
        }

        return ans;
    }
}