#if DEBUG
namespace Weekly_449_Q1;
#endif

public class Solution
{
    public int MinDeletion(string s, int k)
    {
        int[] freq = new int[26];
        foreach (char c in s)
        {
            freq[c - 'a']++;
        }
        int count = 0;
        int sum = 0;
        for (int i = 0; i < 26; i++)
        {
            if (freq[i] > 0) count++;
            sum += freq[i];
        }
        Array.Sort(freq, (a, b) => b - a);

        if (count <= k) return 0;
        for (int i = 0; i < k; i++)
        {
            sum -= freq[i];
        }
        return sum;
    }
}