#if DEBUG
namespace Problems_201;
#endif

public class Solution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        int ans = right & left;
        while (right > left)
        {
            right &= right - 1; // flip right last set bit
            ans &= right;
        }
        return ans;
    }
}