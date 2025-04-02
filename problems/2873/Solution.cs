#if DEBUG
namespace Problems_2873;
#endif

public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    long val = 1L * (nums[i] - nums[j]) * nums[k];
                    ans = Math.Max(ans, val);
                }
            }
        }
        return ans;
    }
}