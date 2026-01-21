#if DEBUG
namespace Problems_3315;
#endif

public class Solution
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        int n = nums.Count;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int j = 1;
            while ((nums[i] & j) != 0)
            {
                j <<= 1;
            }
            j >>= 1;
            if (j == 0) ans[i] = -1;
            else
            {
                ans[i] = nums[i] & (~j);
            }
        }
        return ans;
    }
}