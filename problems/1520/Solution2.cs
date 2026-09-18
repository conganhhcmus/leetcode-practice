public class Solution
{
    public IList<string> MaxNumOfSubstrings(string s)
    {
        int n = s.Length;
        // with each char
        // subs[idx] = [st, ed]
        // sort by (st, ed)
        List<int[]> points = [];
        int[] last = new int[26];
        int[] first = new int[26];
        Array.Fill(last, -1);
        Array.Fill(first, -1);
        for (int i = 0; i < n; i++) last[s[i] - 'a'] = i;
        for (int i = n - 1; i >= 0; i--) first[s[i] - 'a'] = i;

        for (int i = 0; i < 26; i++)
        {
            if (last[i] == -1 || first[i] == -1) continue;
            int st = first[i], ed = last[i];
            int j = st;
            bool isOk = true;
            while (j <= ed)
            {
                int idx = s[j] - 'a';
                if (first[idx] < st)
                {
                    isOk = false;
                    break;
                }
                ed = Math.Max(ed, last[idx]);
                j++;
            }
            if (isOk) points.Add([st, ed]);
        }
        points.Sort((a, b) => a[1].CompareTo(b[1]));
        List<string> ans = [];
        int lastEnd = -1;
        foreach (int[] p in points)
        {
            if (p[0] > lastEnd)
            {
                ans.Add(s.Substring(p[0], p[1] - p[0] + 1));
                lastEnd = p[1];
            }
        }
        return ans;
    }
}