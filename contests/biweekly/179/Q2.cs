public class Solution
{
    int mod = (int)1e9 + 7;

    long Power(long b, long e)
    {
        long r = 1;
        b %= mod;
        while (e > 0)
        {
            if ((e & 1) == 1) r = r * b % mod;
            b = (b * b) % mod;
            e >>= 1;
        }
        return r;
    }

    public int CountVisiblePeople(int n, int pos, int k)
    {
        int limit = Math.Min(k, n - 1 - k);
        // Ckn = n! / (k! * (n-k)!)
        // Ckn = (n * (n-1) * (n-k+1)) / k!
        long num = 1, den = 1;
        for (int i = 1; i <= limit; i++)
        {
            num = (num * (n - i)) % mod;
            den = (den * i) % mod;
        }
        long ans = num * Power(den, mod - 2) % mod;

        return (int)(2L * ans % mod);
    }
}