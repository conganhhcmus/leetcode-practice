public class Solution
{
    public long SumAndMultiply(int n)
    {
        long sum = 0;
        long x = 0;
        long b = 1;
        while (n > 0)
        {
            int d = n % 10;
            n /= 10;
            if (d == 0) continue;
            sum += d;
            x += d * b;
            b *= 10;
        }

        return x * sum;
    }
}
