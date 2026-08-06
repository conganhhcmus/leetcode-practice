public class Solution
{
    public int SmallestNumber(int n, int t)
    {
        for (int i = n; i <= n + 10; i++)
        {
            int p = 1;
            int tmp = i;
            while (tmp > 0)
            {
                p *= tmp % 10;
                tmp /= 10;
            }
            if (p % t == 0) return i;
        }
        return -1;
    }
}
