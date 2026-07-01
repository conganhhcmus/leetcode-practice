public class Solution
{
    public int MinCut(string s)
    {
        int n = s.Length;
        string rev = new([.. s.Reverse()]);
        RollingHash H = new(s);
        RollingHash R = new(rev);
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (IsPalindrome(j, i - 1))
                {
                    dp[i] = Math.Min(dp[i], dp[j] + 1);
                }
            }
        }
        return dp[n] - 1;

        bool IsPalindrome(int l, int r)
        {
            int rl = n - 1 - r;
            int rr = n - 1 - l;
            return H.GetHash(l, r) == R.GetHash(rl, rr);
        }
    }

    class RollingHash
    {
        const long MOD1 = 1_000_000_007;
        const long MOD2 = 1_000_000_009;
        const long BASE = 911382323;

        long[] h1, h2;
        long[] p1, p2;
        public RollingHash(string s)
        {
            int n = s.Length;
            h1 = new long[n + 1];
            h2 = new long[n + 1];
            p1 = new long[n + 1];
            p2 = new long[n + 1];

            p1[0] = 1;
            p2[0] = 1;
            for (int i = 0; i < n; i++)
            {
                h1[i + 1] = (h1[i] * BASE + s[i]) % MOD1;
                h2[i + 1] = (h2[i] * BASE + s[i]) % MOD2;

                p1[i + 1] = p1[i] * BASE % MOD1;
                p2[i + 1] = p2[i] * BASE % MOD2;
            }
        }

        public (long, long) GetHash(int l, int r)
        {
            if (l > r) return (0, 0);
            long x1 = (h1[r + 1] - h1[l] * p1[r - l + 1]) % MOD1;
            if (x1 < 0) x1 += MOD1;
            long x2 = (h2[r + 1] - h2[l] * p2[r - l + 1]) % MOD2;
            if (x2 < 0) x2 += MOD2;
            return (x1, x2);
        }
    }
}
