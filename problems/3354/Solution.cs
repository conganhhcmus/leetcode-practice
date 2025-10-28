#if DEBUG
namespace Problems_3354;
#endif

public class Solution
{
    public int CountValidSelections(int[] nums)
    {
        int n = nums.Length;
        int[] prefixSum = new int[n + 1];
        int total = 0;
        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
            total += nums[i];
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                if (2 * prefixSum[i] == total)
                {
                    ans += 2;
                }
                else if (Math.Abs(total - 2 * prefixSum[i]) == 1)
                {
                    ans++;
                }
            }
        }
        return ans;
    }
}