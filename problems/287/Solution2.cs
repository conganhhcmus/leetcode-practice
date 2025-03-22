#if DEBUG
namespace Problems_287_2;
#endif

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        for (int bit = 0; bit < 32; ++bit)
        {
            int curr = 0, def = 0; // default
            for (int i = 0; i < n; ++i)
            {
                curr += (nums[i] >> bit) & 1;
                def += (i >> bit) & 1;
            }
            if (curr > def) ans |= 1 << bit;
        }

        return ans;
    }
}