public class Solution
{
    const long MOD = 1_000_000_007;

    public int ZigZagArrays(int n, int l, int r)
    {
        long m = r - l + 1;
        if (m == 1) return 0;
        int k = n + 1;
        long[] ys = new long[k + 1];

        for (int x = 1; x <= k; x++)
        {
            ys[x] = CountForM(n, x);
        }

        return (int)Lagrange(ys, k, m);
    }

    long CountForM(int n, int m)
    {
        if (m == 1) return 0;
        long[] up = new long[m];
        long[] down = new long[m];
        for (int x = 0; x < m; x++)
        {
            up[x] = x;
            down[x] = m - 1 - x;
        }
        if (n == 2)
        {
            long ans = 0;
            for (int i = 0; i < m; i++)
            {
                ans += up[i] + down[i];
            }
            return ans % MOD;
        }

        for (int len = 3; len <= n; len++)
        {
            long[] prefUp = new long[m + 1];
            long[] prefDown = new long[m + 1];
            for (int i = 0; i < m; i++)
            {
                prefUp[i + 1] = (prefUp[i] + up[i]) % MOD;
                prefDown[i + 1] = (prefDown[i] + down[i]) % MOD;
            }
            long[] nextUp = new long[m];
            long[] nextDown = new long[m];
            for (int x = 0; x < m; x++)
            {
                nextUp[x] = prefDown[x];
                nextDown[x] = (prefUp[m] - prefUp[x + 1] + MOD) % MOD;
            }
            up = nextUp;
            down = nextDown;
        }

        long res = 0;
        for (int i = 0; i < m; i++)
        {
            res += up[i] + down[i];
        }
        return res % MOD;
    }

    long Pow(long a, long e)
    {
        long r = 1;
        while (e > 0)
        {
            if ((e & 1) != 0) r = r * a % MOD;
            a = a * a % MOD;
            e >>= 1;
        }
        return r;
    }

    long Lagrange(long[] y, int k, long x)
    {
        if (x <= k) return y[(int)x];

        long[] fact = new long[k + 2];
        long[] ifact = new long[k + 2];

        fact[0] = 1;
        for (int i = 1; i <= k; i++)
        {
            fact[i] = fact[i - 1] * i % MOD;
        }

        ifact[k] = Pow(fact[k], MOD - 2);
        for (int i = k; i >= 1; i--)
        {
            ifact[i - 1] = ifact[i] * i % MOD;
        }

        long[] pre = new long[k + 2];
        long[] suf = new long[k + 2];

        pre[0] = 1;
        for (int i = 1; i <= k; i++)
        {
            long v = (x - i) % MOD;
            if (v < 0) v += MOD;
            pre[i] = pre[i - 1] * v % MOD;
        }

        suf[k + 1] = 1;
        for (int i = k; i >= 1; i--)
        {
            long v = (x - i) % MOD;
            if (v < 0) v += MOD;
            suf[i] = suf[i + 1] * v % MOD;
        }

        long ans = 0;
        for (int i = 1; i <= k; i++)
        {
            long num = pre[i - 1] * suf[i + 1] % MOD;
            long den = ifact[i - 1] * ifact[k - i] % MOD;
            if (((k - i) & 1) == 1) den = (MOD - den) % MOD;

            ans += y[i] * num % MOD * den % MOD;
            if (ans >= MOD) ans -= MOD;
        }

        return ans;
    }
}
