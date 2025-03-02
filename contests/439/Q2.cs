#if DEBUG
namespace Contests_439_Q2;
#endif

public class Solution
{
    public int LongestPalindromicSubsequence(string s, int k)
    {
        int[] freq = new int[26];
        foreach (char c in s)
        {
            freq[c - 'a']++;
        }
        int count = 0;
        for (int i = 0; i < 26; i++)
        {
            count += freq[i] / 2;
            freq[i] %= 2;
        }
        int ans = 0;
        for (int i = 0; i < 26; i++)
        {
            int next = (i + 1) % 26;
            int prev = (i + 25) % 26;
            int tmp = k;
            int diff = 1;
            int val = freq[i];
            while (tmp > 0 && diff < (26 - 1) / 2)
            {
                int changeNext = Math.Min(Math.Max(0, tmp / diff), freq[next]);
                val += changeNext;
                tmp -= changeNext * diff;
                int changePrev = Math.Min(Math.Max(0, tmp / diff), freq[prev]);
                val += changePrev;
                tmp -= changePrev * diff;
                diff++;
                next = (next + 1) % 26;
                prev = (prev + 25) % 26;
            }

            ans = Math.Max(ans, count + val);
        }
        return ans;
    }
}