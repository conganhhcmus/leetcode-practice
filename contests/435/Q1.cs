#if DEBUG
namespace Contests_435_Q1;
#endif

public class Solution
{
    public int MaxDifference(string s)
    {
        int[] freq = new int[26];
        foreach (char c in s)
        {
            freq[c - 'a']++;
        }
        int max = 0, min = s.Length;
        for (int i = 0; i < 26; i++)
        {
            if (freq[i] == 0) continue;
            if (freq[i] % 2 == 0)
            {
                min = Math.Min(min, freq[i]);
            }
            else
            {
                max = Math.Max(max, freq[i]);
            }
        }

        return max - min;
    }
}