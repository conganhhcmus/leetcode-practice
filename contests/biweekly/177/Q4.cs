public class Solution
{
    int mod = (int)1e9 + 7;

    long FastPow(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) != 0)
            {
                ans = ans * a % mod;
            }
            b >>= 1;
            a = a * a % mod;
        }
        return ans;
    }

    long Calc(long k, long n)
    {
        // n-1 ^ (k -1) ways
        long ways = FastPow(n, k - 1);
        // k position
        // each position has
        // d........
        // .d.......
        // ..d......
        // => d * 111...111 which k element
        // = d * (10^0 + 10^1 + 10^2 +...+10^(k-1))
        // = d * ((10^k - 1) / 9)
        long pow10 = FastPow(10, k);
        long inv9 = FastPow(9, mod - 2);

        return ways * (pow10 - 1 + mod) % mod * inv9 % mod;
    }

    public int SumOfNumbers(int l, int r, int k)
    {
        long ans = 0;
        int n = r - l + 1;
        long sumBase = Calc(k, n);
        for (int d = l; d <= r; d++)
        {
            ans = (ans + sumBase * d % mod) % mod;
        }

        return (int)(ans % mod);
    }
}