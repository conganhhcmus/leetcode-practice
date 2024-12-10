#if DEBUG
namespace Problems_2981;
#endif

public class Solution
{
    public int MaximumLength(string s)
    {
        int[] chars = new int[26];
        foreach (char c in s)
        {
            chars[c - 'a']++;
        }
        int max = 0;
        for (int i = 0; i < 26; i++)
        {
            max = Math.Max(max, chars[i]);
        }
        if (max < 3) return -1;

        for (int len = max - 2; len > 1; len--)
        {
            Dictionary<string, int> freq = [];
            int st = 0, ed = 1;
            while (ed < s.Length)
            {
                if (s[st] != s[ed])
                {
                    st = ed;
                }
                if (ed - st + 1 == len)
                {
                    string key = s[st..ed];
                    freq[key] = freq.GetValueOrDefault(key, 0) + 1;
                    st++;
                }

                ed++;
            }

            if (freq.Count > 0 && freq.Max(x => x.Value) >= 3) return len;
        }

        return 1;
    }
}