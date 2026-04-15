namespace Library;

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
