#if DEBUG
namespace Problems_2401;
#endif

public class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        int n = nums.Length;
        int bitMask = 0;
        int left = 0;
        int ans = 0;
        for (int right = 0; right < n; right++)
        {
            while (left < right && (bitMask & nums[right]) != 0)
            {
                bitMask ^= nums[left];
                left++;
            }
            bitMask |= nums[right];
            ans = Math.Max(ans, right - left + 1);
        }

        return ans;
    }
}