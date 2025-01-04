#if DEBUG
namespace Problems_1930;
#endif

public class Solution
{
    public int CountPalindromicSubsequence(string s)
    {
        int ans = 0;
        for (char ch = 'a'; ch <= 'z'; ch++)
        {
            int first = s.IndexOf(ch);
            if (first == -1) continue;
            int last = s.LastIndexOf(ch);
            HashSet<char> set = [];
            for (int i = first + 1; i < last && set.Count < 26; i++)
            {
                set.Add(s[i]);
            }
            ans += set.Count;
        }

        return ans;
    }
}