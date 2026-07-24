public class Solution
{
    public long RemoveZeros(long n)
    {
        long ans = 0;
        long b = 1;
        while (n > 0)
        {
            long d = n % 10;
            n /= 10;
            if (d > 0)
            {
                ans += d * b;
                b *= 10;
            }
        }
        return ans;
    }
}
