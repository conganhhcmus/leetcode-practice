public class Solution
{
    public string ShortestPalindrome(string s)
    {
        int n = s.Length;
        int M = 31;
        RollingHash61 h1 = new(M, n);
        RollingHash61 h2 = new(M, n);
        for (int i = 0; i < n; i++)
        {
            h1.Add(s[i] - 'a' + 1);
            h2.Add(s[n - i - 1] - 'a' + 1);
        }
        int p = -1;
        for (int i = 0; i < n; i++)
        {
            if (h1.Hash(0, i + 1) == h2.Hash(n - i - 1, n))
            {
                p = i;
            }
        }
        StringBuilder sb = new();
        for (int i = n - 1; i > p; i--)
        {
            sb.Append(s[i]);
        }
        for (int i = 0; i < n; i++)
        {
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
}

// 61 bits
public class RollingHash61
{
    static long mod = (1L << 61) - 1;
    long M;
    long[] pows;
    long[] hash;
    int len;

    public RollingHash61(long M, int n)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(M, 0);
        ArgumentOutOfRangeException.ThrowIfLessThan(n, 0);
        this.M = M;
        this.pows = MakePows(M, n);
        this.hash = new long[n + 1];
        this.len = 0;
    }

    long Mul(long a, long b)
    {
        long al = a & (1L << 31) - 1,
            ah = a >>> 31;
        long bl = b & (1L << 31) - 1,
            bh = b >>> 31;
        long low = al * bl; // <2^62
        long mid = al * bh + bl * ah; // < 2^62
        long high = ah * bh + (mid >>> 31); // < 2^60 + 2^31 < 2^61
        // high*2^62 = high*2 (mod 2^61-1)
        long ret = Mod(Mod(2 * high + low) + ((mid & (1L << 31) - 1) << 31));
        return ret;
    }

    long Mod(long a)
    {
        a %= mod;
        return a < 0 ? a + mod : a;
    }

    long[] MakePows(long M, int n)
    {
        long[] ret = new long[n + 1];
        ret[0] = 1;
        for (int i = 1; i <= n; i++)
            ret[i] = Mul(ret[i - 1], M);
        return ret;
    }

    public void Add(long x)
    {
        hash[len + 1] = Mod(Mul(hash[len], M) + x);
        len++;
    }

    public long Hash(int l, int r)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(r - l, 0);
        ArgumentOutOfRangeException.ThrowIfLessThan(len - r, 0);
        return Mod(hash[r] - Mul(hash[l], pows[r - l]));
    }
}
