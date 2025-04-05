#if DEBUG
namespace Problems_1863;
#endif

public class Solution
{
    public int SubsetXORSum(int[] nums)
    {
        int n = nums.Length;
        int max = 1 << n;
        int ans = 0;
        for (int bitmask = 0; bitmask < max; bitmask++)
        {
            ans += CalcXOR(nums, bitmask);
        }
        return ans;
    }

    int CalcXOR(int[] nums, int bitmask)
    {
        int xor = 0;
        int idx = 0;
        while (bitmask > 0)
        {
            if ((bitmask & 1) != 0) xor ^= nums[idx];
            idx++;
            bitmask >>= 1;
        }
        return xor;
    }
}