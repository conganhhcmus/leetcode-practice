public class Solution
{
    public int MakeTheIntegerZero(int num1, int num2)
    {
        int k = 1;
        while (true)
        {
            long x = num1 - 1L * k * num2;
            if (x < k) return -1;
            if (k >= BitCount(x))
            {
                return k;
            }
            k++;
        }
    }
    int BitCount(long n)
    {
        int count = 0;
        while (n != 0)
        {
            count++;
            n &= (n - 1);
        }
        return count;
    }
}