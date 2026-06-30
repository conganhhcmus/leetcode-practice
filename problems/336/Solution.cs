public class Solution
{
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        int n = words.Length;
        IList<IList<int>> ans = [];
        Dictionary<(long, long), int> dict = [];
        for (int i = 0; i < n; i++)
        {
            string w = words[i];
            RollingHash H = new(w);
            var key = H.GetHash(0, w.Length - 1);
            dict[key] = i;
        }
        HashSet<(int, int)> seen = [];
        for (int i = 0; i < n; i++)
        {
            string w = words[i];
            string rev = new([.. w.Reverse()]);
            int m = w.Length;
            RollingHash H = new(w);
            RollingHash R = new(rev);
            for (int split = 0; split <= m; split++)
            {
                // prefix = [0, split]
                // suffix = [split, m)
                // prefix palindrome
                if (split == 0 || IsPalindrome(H, R, 0, split - 1, m))
                {
                    // string need = new([.. w[split..].Reverse()]);
                    var key = R.GetHash(0, m - split - 1);
                    if (dict.TryGetValue(key, out int j) && i != j && seen.Add((j, i)))
                    {
                        ans.Add([j, i]);
                    }
                }

                // suffix palindrome
                if (split == m || IsPalindrome(H, R, split, m - 1, m))
                {
                    // string need = new([.. w[..split].Reverse()]);
                    var key = R.GetHash(m - split, m - 1);
                    if (dict.TryGetValue(key, out int j) && i != j && seen.Add((i, j)))
                    {
                        ans.Add([i, j]);
                    }
                }
            }
        }

        return ans;
    }

    bool IsPalindrome(RollingHash H, RollingHash R, int l, int r, int n)
    {
        int rl = n - 1 - r;
        int rr = n - 1 - l;
        return H.GetHash(l, r) == R.GetHash(rl, rr);
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
