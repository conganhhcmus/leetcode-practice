#if DEBUG
namespace Problems_76;
#endif

public class Solution
{
    public string MinWindow(string s, string t)
    {
        Dictionary<char, int> freq = [];
        foreach (char c in t) freq[c] = freq.GetValueOrDefault(c, 0) + 1;
        int left = 0, right = 0, count = t.Length, n = s.Length;
        int start = 0, end = 0, len = int.MaxValue;

        while (right < n)
        {
            if (freq.ContainsKey(s[right]))
            {
                if (freq[s[right]] > 0) count--;
                freq[s[right]]--;
            }
            right++;
            while (count == 0)
            {
                if (len > right - left)
                {
                    len = right - left;
                    start = left;
                    end = right;
                }

                if (freq.ContainsKey(s[left]))
                {
                    freq[s[left]]++;
                    if (freq[s[left]] > 0) count++;
                }
                left++;
            }
        }

        return (len == int.MaxValue) ? "" : s[start..end];
    }
}