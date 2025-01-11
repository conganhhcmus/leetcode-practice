#if DEBUG
namespace Problems_1400;
#endif

public class Solution
{
    public bool CanConstruct(string s, int k)
    {
        if (s.Length < k) return false;
        int[] count = new int[26];
        foreach (char c in s) count[c - 'a']++;
        for (int i = 0; i < 26; i++)
        {
            k -= count[i] & 1;
        }
        return k >= 0;
    }
}