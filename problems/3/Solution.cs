#if DEBUG
namespace Problems_3;
#endif

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var set = new HashSet<char>();
        int max = Math.Min(1, s.Length);
        int l = 0, r = 0;
        while (r < s.Length)
        {
            while (r < s.Length && set.Add(s[r])) r++;
            set.Remove(s[l]);
            max = Math.Max(max, r - l);
            l++;
        }

        return max;
    }
}