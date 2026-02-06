#if DEBUG
namespace Weekly_484_Q3;
#endif

public class Solution
{
    public long CountPairs(string[] words)
    {
        Dictionary<string, int> freq = [];
        foreach (string s in words)
        {
            string t = Format(s);
            freq[t] = freq.GetValueOrDefault(t, 0) + 1;
        }
        long ans = 0;
        foreach (int v in freq.Values)
        {
            ans += 1L * v * (v - 1) / 2;
        }
        return ans;
    }

    string Format(string s)
    {
        int need = s[0] - 'a';
        StringBuilder sb = new();
        foreach (char c in s)
        {
            int curr = c - 'a';
            int add = ((curr - need) % 26 + 26) % 26;
            sb.Append('a' + add);
        }
        return sb.ToString();
    }
}