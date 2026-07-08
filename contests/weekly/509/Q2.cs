public class Solution
{
    public bool CanMakeSubsequence(string s, string t)
    {
        int n = s.Length, m = t.Length;
        if (n > m) return false;
        int INF = 1 << 30;
        int[] pref = new int[n + 1];
        // pref[i+1] = position in t where match s[..i]
        // pref[i] not contain element i
        Array.Fill(pref, INF);
        pref[0] = -1;
        int j = 0;
        for (int i = 0; i < n; i++)
        {
            while (j < m && t[j] != s[i]) j++;
            if (j == m) break;
            pref[i + 1] = j;
            j++;
        }
        int[] suff = new int[n + 1];
        // suff[i] = position in t where match s[i..]
        // suff[i] contain element i
        Array.Fill(suff, -INF);
        suff[n] = m;
        j = m - 1;
        for (int i = n - 1; i >= 0; i--)
        {
            while (j >= 0 && t[j] != s[i]) j--;
            if (j < 0) break;
            suff[i] = j;
            j--;
        }

        for (int i = 0; i < n; i++)
        {
            if (pref[i] == INF) break;
            if (suff[i + 1] == -INF) continue;
            if (pref[i] + 1 < suff[i + 1]) return true;
        }
        return false;
    }
}
