public class Solution
{
    public long SumScores(string s)
    {
        int n = s.Length;
        int p = 31;
        RollingHash rh = new(n, p);
        for (int i = 0; i < n; i++)
        {
            rh.Add(s[i] - 'a' + 1);
        }

        long sum = 0;

        for (int i = 0; i < n; i++)
        {
            // find the length of s[0...] & s[i...]
            int l = 0,
                r = n - 1 - i,
                a = 0;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (rh.Hash(0, m) == rh.Hash(i, i + m))
                {
                    a = m + 1; // 0..m has m+1 len
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }
            sum += a;
        }

        return sum;
    }
}

public class RollingHash
{
    long mod = (long)1e9 + 7;
    long p = 31;
    int n;
    long[] hash;
    long[] pow;
    int len;

    public RollingHash(int n, int p)
    {
        this.len = 0;
        this.n = n;
        this.p = p;
        hash = new long[n + 1];
        pow = new long[n + 1];

        pow[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            pow[i] = Mod(pow[i - 1] * p);
        }
    }

    long Mod(long a) => (a % mod + mod) % mod;

    public void Add(long val)
    {
        hash[len + 1] = Mod(hash[len] * p + val);
        len++;
    }

    // hash from [l..r]
    public long Hash(int l, int r)
    {
        return Mod(hash[r + 1] - Mod(hash[l] * pow[r - l + 1]));
    }
}
