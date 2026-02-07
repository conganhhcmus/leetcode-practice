public class Solution
{
    public int LongestPalindrome(string s, string t)
    {
        char[] s1 = s.ToCharArray();
        char[] s2 = t.ToCharArray();
        return Math.Max(Go(s1, Reverse(s2)), Go(Reverse(s2), s1));
    }

    char[] Reverse(char[] s)
    {
        int n = s.Length;
        char[] ret = new char[n];
        Array.Copy(s, ret, n);
        for (int i = 0; i < n / 2; i++)
        {
            (ret[i], ret[n - 1 - i]) = (ret[n - 1 - i], ret[i]);
        }
        return ret;
    }

    int Go(char[] s1, char[] s2)
    {
        int mod = (int)1e9 + 7;
        int n1 = s1.Length, n2 = s2.Length;
        RollingHash61 rh1 = new(mod, n1);
        RollingHash61 rh2 = new(mod, n2);
        for (int i = 0; i < n1; i++)
        {
            rh1.Add(s1[i]);
        }

        for (int i = 0; i < n2; i++)
        {
            rh2.Add(s2[i]);
        }

        HashSet<long> all = [];
        for (int i = 0; i < n2; i++)
        {
            for (int j = i; j <= n2; j++)
            {
                all.Add(rh2.Hash(i, j));
            }
        }
        int ret = 0;

        for (int i = 0; i < n1; i++)
        {
            // even ~ abba
            int count = 0;
            for (int j = 0; j <= n1 && i + j + 1 < n1 && i - j >= 0; j++)
            {
                if (s1[i - j] == s1[i + j + 1]) count++;
                else break;
            }
            count += GetExtra(rh1, all, i - count);
            ret = Math.Max(ret, 2 * count);
        }

        for (int i = 0; i < n1; i++)
        {
            // odd ~ aba
            int count = 0;
            for (int j = 1; j <= n1 && i + j < n1 && i - j >= 0; j++)
            {
                if (s1[i - j] == s1[i + j]) count++;
                else break;
            }
            count += GetExtra(rh1, all, i - count - 1);
            ret = Math.Max(ret, 2 * count + 1);
        }

        return ret;
    }

    int GetExtra(RollingHash61 rh1, HashSet<long> all, int pos)
    {
        int low = 0, high = pos + 1, ans = pos + 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            long hash = rh1.Hash(mid, pos + 1);
            if (all.Contains(hash))
            {
                ans = mid;
                high = mid - 1;
            }
            else low = mid + 1;
        }

        return pos - ans + 1;
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
        long al = a & (1L << 31) - 1, ah = a >>> 31;
        long bl = b & (1L << 31) - 1, bh = b >>> 31;
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
        for (int i = 1; i <= n; i++) ret[i] = Mul(ret[i - 1], M);
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