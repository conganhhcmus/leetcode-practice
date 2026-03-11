public class Solution
{
    public int BitwiseComplement(int n)
    {
        if (n == 0) return 1;
        int count = 0;
        int temp = n;
        while (temp > 0)
        {
            count++;
            temp >>= 1;
        }
        int mask = (1 << count) - 1;
        return ~n & mask;
    }
}