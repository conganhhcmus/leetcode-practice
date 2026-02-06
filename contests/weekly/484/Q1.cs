#if DEBUG
namespace Weekly_484_Q1;
#endif

public class Solution
{
    public int ResiduePrefixes(string s)
    {
        int ans = 0;
        HashSet<char> set = [];
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            set.Add(s[i]);
            if (set.Count == (i + 1) % 3) ans++;
        }

        return ans;
    }
}