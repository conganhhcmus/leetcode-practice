public class Solution
{
    public char FindKthBit(int n, int k)
    {
        if (n == 1) return '0';
        int len = 1 << n;
        int mid = len / 2;
        if (k == mid) return '1';
        if (k < mid) return FindKthBit(n - 1, k);
        char bit = FindKthBit(n - 1, len - k);
        return bit == '1' ? '0' : '1';
    }
}