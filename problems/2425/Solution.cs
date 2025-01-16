#if DEBUG
namespace Problems_2425;
#endif

public class Solution
{
    public int XorAllNums(int[] nums1, int[] nums2)
    {
        int xorN1 = (nums2.Length % 2 == 0) ? 0 : XorAllNums(nums1);
        int xorN2 = (nums1.Length % 2 == 0) ? 0 : XorAllNums(nums2);
        return xorN1 ^ xorN2;
    }

    private int XorAllNums(int[] nums)
    {
        int xorRes = 0;
        foreach (int num in nums)
        {
            xorRes ^= num;
        }
        return xorRes;
    }
}