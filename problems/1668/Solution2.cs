#if DEBUG
namespace Problems_1668_2;
#endif

public class Solution
{
    public int MaxRepeating(string sequence, string word)
    {
        int n = sequence.Length, m = word.Length;
        int[] f = new int[n + 1];
        // f[i] = max repeated end of i
        // f[i] = f[i-m] + 1 if s[i-m..i] == word, otherwise zero
        int max = 0;
        for (int i = m; i <= n; i++)
        {
            if (sequence[(i - m)..i] == word)
            {
                f[i] = f[i - m] + 1;
            }
            max = Math.Max(max, f[i]);
        }
        return max;
    }
}