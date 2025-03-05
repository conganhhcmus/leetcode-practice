#if DEBUG
namespace Contests_433_Q1;
#endif

public class Solution
{
    public int SubarraySum(int[] nums)
    {
        int ans = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int j = Math.Max(0, i - nums[i]);
            for (; j <= i; j++)
            {
                ans += nums[j];
            }
        }

        return ans;
    }
}