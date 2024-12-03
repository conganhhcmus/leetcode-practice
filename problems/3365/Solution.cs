namespace Problem_3365;
public class Solution
{
    public bool IsPossibleToRearrange(string s, string t, int k)
    {
        Dictionary<string, int> freq = [];
        int len = s.Length / k;
        for (int i = 0; i + len <= s.Length; i += len)
        {
            string key = s[i..(i + len)];
            freq[key] = freq.GetValueOrDefault(key, 0) + 1;
        }
        for (int i = 0; i + len <= t.Length; i += len)
        {
            string key = t[i..(i + len)];
            freq[key] = freq.GetValueOrDefault(key, 0) - 1;
        }

        foreach (int val in freq.Values)
        {
            if (val != 0) return false;
        }

        return true;
    }
}