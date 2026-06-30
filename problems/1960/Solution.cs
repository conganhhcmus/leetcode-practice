public class Solution
{
    public long MaxProduct(string s)
    {
        int n = s.Length;
        string rev = new([.. s.Reverse()]);
        int[] l2r = Manacher(s);
        int[] r2l = Manacher(rev);
        long ans = 0L;
        for (int i = 0; i < n - 1; i++)
        {
            int j = n - i - 2;
            ans = Math.Max(ans, 1L * l2r[i] * r2l[j]);
        }

        return ans;
    }

    int[] Manacher(string s)
    {
        int n = s.Length;
        int[] p = new int[n];
        int[] pref = new int[n];
        Array.Fill(pref, 1);
        int c = 0, r = -1;
        for (int i = 0; i < n; i++)
        {
            int m = 2 * c - i;
            if (i < r) p[i] = Math.Min(p[m], r - i);
            while (i - p[i] - 1 >= 0
                && i + p[i] + 1 < n
                && s[i - p[i] - 1] == s[i + p[i] + 1])
            {
                p[i]++;
                pref[i + p[i]] = 2 * p[i] + 1;
            }
            if (i + p[i] > r)
            {
                c = i;
                r = i + p[i];
            }
        }
        for (int i = 1; i < n; i++)
        {
            pref[i] = Math.Max(pref[i], pref[i - 1]);
        }
        return pref;
    }
}
