#if DEBUG
namespace Weekly_487_Q2;
#endif

public class Solution
{
    public int FinalElement(int[] nums)
    {
        return Math.Max(nums[0], nums[^1]);
    }
}