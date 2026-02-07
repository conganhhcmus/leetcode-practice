public class Solution
{
    public int TrailingZeroes(int n)
    {
        int count5 = 0;
        int count2 = 0;
        for (int i = 1; i <= n; i++)
        {
            count2 += FactK(i, 2);
            count5 += FactK(i, 5);
        }
        return Math.Min(count2, count5);
    }

    int FactK(int n, int k)
    {
        int count = 0;
        while (n % k == 0)
        {
            count++;
            n /= k;
        }
        return count;
    }
}