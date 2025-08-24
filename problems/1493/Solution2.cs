#if DEBUG
namespace Problems_1493_2;
#endif

public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        int prev = -1;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 1)
            {
                count++;
            }
            else
            {
                ans = Math.Max(ans, count + prev);
                prev = count;
                count = 0;
            }
        }
        ans = Math.Max(ans, count + prev);
        return ans;
    }
}