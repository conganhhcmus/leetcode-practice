public class Solution
{
    public int[] SortByReflection(int[] nums)
    {
        Array.Sort(nums, (a, b) =>
        {
            int bra = BinaryReflection(a);
            int brb = BinaryReflection(b);
            if (bra == brb) return a - b;
            return bra - brb;
        });
        return nums;

        int BinaryReflection(int a)
        {
            int b = 0;
            while (a > 0)
            {
                if ((a & 1) == 1) b |= 1;
                b <<= 1;
                a >>= 1;
            }
            return b;
        }
    }
}
