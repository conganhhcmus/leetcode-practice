public class Solution
{
    public string ShortestBeautifulSubstring(string s, int k)
    {
        int n = s.Length;
        int cnt = 0;
        int len = n + 1;
        string ans = "";
        for (int i = 0, j = 0; i < n; i++)
        {
            if (s[i] == '1') cnt++;
            while (j < i && cnt > k)
            {
                if (s[j] == '1') cnt--;
                j++;
            }
            if (cnt == k)
            {
                while (s[j] == '0') j++;
                int l = i - j + 1;
                string t = s.Substring(j, l);
                if (l < len)
                {
                    len = l;
                    ans = t;
                }
                else if (l == len)
                {
                    if (ans.CompareTo(t) > 0) ans = t;
                }
            }
        }
        return ans;
    }
}