public class Solution
{
    public string ShortestBeautifulSubstring(string s, int k)
    {
        int n = s.Length;
        int cnt = 0;
        for (int i = 0; i < n; i++) if (s[i] == '1') cnt++;
        if (cnt < k) return "";
        cnt = 0;
        string ans = s;
        for (int i = 0, j = 0; i < n; i++)
        {
            if (s[i] == '1') cnt++;
            while (cnt > k || s[j] == '0')
            {
                if (s[j] == '1') cnt--;
                j++;
            }
            if (cnt == k)
            {
                string t = s.Substring(j, i - j + 1);
                if (t.Length < ans.Length || (t.Length == ans.Length && t.CompareTo(ans) < 0))
                {
                    ans = t;
                }
            }
        }
        return ans;
    }
}