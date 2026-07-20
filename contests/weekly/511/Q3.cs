public class Solution
{
    public bool[] TransformStr(string s, string[] strs)
    {
        int n = s.Length;
        int m = strs.Length;
        int ones = 0, zeros = 0;
        List<int> idx = [];
        for (int i = n - 1; i >= 0; i--)
        {
            char c = s[i];
            if (c == '0') zeros++;
            else
            {
                ones++;
                idx.Add(i);
            }
        }
        bool[] ans = new bool[m];
        for (int i = 0; i < m; i++)
        {
            char[] t = strs[i].ToCharArray();
            // cnt one & zero in s & t is equals
            // can move one to back not move front
            // the one in s need after or equal one in t
            int extra = 0;
            int cnt0 = 0;
            int cnt1 = 0;
            foreach (char c in t)
            {
                if (c == '?') extra++;
                else if (c == '1') cnt1++;
                else cnt0++;
            }
            if (cnt0 > zeros || cnt1 > ones) ans[i] = false;
            else
            {
                ans[i] = true;
                int need = ones - cnt1;
                List<int> idx2 = [];
                for (int j = t.Length - 1; j >= 0; j--)
                {
                    if (t[j] == '?' && need > 0)
                    {
                        t[j] = '1';
                        need--;
                    }
                    if (t[j] == '1') idx2.Add(j);
                }
                if (idx.Count != idx2.Count) ans[i] = false;
                else
                {
                    for (int k = idx.Count - 1; k >= 0; k--)
                    {
                        if (idx[k] > idx2[k])
                        {
                            ans[i] = false;
                            break;
                        }
                    }
                }
            }
        }
        return ans;
    }
}
