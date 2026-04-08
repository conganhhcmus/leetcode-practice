public class Solution
{
    public int XorBeauty(int[] nums)
    {
        int xor = 0;
        foreach (int num in nums)
        {
            xor ^= num;
        }
        return xor;
    }
}