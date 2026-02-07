public class Solution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        int x = left ^ right;
        if (x == 0) return left;

        x |= x >> 1;
        x |= x >> 2;
        x |= x >> 4;
        x |= x >> 8;
        x |= x >> 16;
        x -= x >> 1;

        x |= x - 1;
        x = ~x;

        return left & x;
    }
}