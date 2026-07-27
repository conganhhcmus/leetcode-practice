public class Solution
{
    int MOD = 1_000_000_007;
    public int CountValidSequences(int n, int k)
    {
        if (n < k) return 0;
        long[] fac = new long[n + 1];
        long[] invFac = new long[n + 1];
        fac[0] = 1;
        for (int i = 1; i <= n; i++) fac[i] = fac[i - 1] * i % MOD;
        invFac[n] = Pow(fac[n], MOD - 2);
        for (int i = n; i >= 1; i--) invFac[i - 1] = invFac[i] * i % MOD;

        long ans = C(n - 1, k - 1, fac, invFac);
        if (((n - k) & 1) == 0)
        {
            int m = (n + k - 2) / 2;
            ans = (ans - C(m, k - 1, fac, invFac) + MOD) % MOD;
        }
        return (int)ans;
    }

    long C(int n, int r, long[] fac, long[] invFac)
    {
        if (r < 0 || r > n) return 0;
        return fac[n] * invFac[r] % MOD * invFac[n - r] % MOD;
    }

    long Pow(long a, long e)
    {
        long ans = 1;
        while (e > 0)
        {
            if ((e & 1) != 0)
            {
                ans = ans * a % MOD;
            }
            a = a * a % MOD;
            e >>= 1;
        }
        return ans;
    }
}
