#if DEBUG
namespace Problems_2873_2;
#endif

public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        int max = 0;
        for (int k = 0; k < n; k++)
        {
            ans = Math.Max(ans, 1L * max * nums[k]);
            for (int i = 0, j = k; i < j; i++)
            {
                max = Math.Max(max, nums[i] - nums[j]);
            }
        }
        return ans;
    }
}