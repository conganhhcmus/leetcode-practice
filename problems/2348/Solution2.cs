#if DEBUG
namespace Problems_2348_2;
#endif

public class Solution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        for (int i = 0, j = 0; i < n; i++)
        {
            if (nums[i] != 0) continue;
            if (j < i) j = i;
            while (j < n && nums[j] == 0) j++;
            ans += j - i;
        }
        return ans;
    }
}