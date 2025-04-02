#if DEBUG
namespace Problems_2874_2;
#endif

public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        int n = nums.Length;
        int[] leftMax = new int[n + 1];
        int[] rightMax = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], nums[i - 1]);
            rightMax[n - i] = Math.Max(rightMax[n - i + 1], nums[n - i]);
        }

        long ans = 0;
        for (int j = 0; j < n; j++)
        {
            long val = 1L * (leftMax[j] - nums[j]) * rightMax[j + 1];
            ans = Math.Max(ans, val);
        }
        return ans;
    }
}