public class Solution
{
    public string ShortestBeautifulSubstring(string s, int k)
    {
        int n = s.Length;
        int cnt = 0;
        Dictionary<int, int> map = [];
        map[0] = -1;
        int maxL = n + 1;
        string ans = "";
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1') cnt++;
            int need = cnt - k;
            if (map.TryGetValue(need, out int j))
            {
                int len = i - j;
                string t = s.Substring(j + 1, len);
                if (len < maxL)
                {
                    maxL = len;
                    ans = t;
                }
                else if (len == maxL)
                {
                    if (ans.CompareTo(t) > 0) ans = t;
                }
            }

            map[cnt] = i;
        }

        return ans;
    }
}
