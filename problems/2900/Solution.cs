#if DEBUG
namespace Problems_2900;
#endif

public class Solution
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        // f[i][last] is longest subsequence end is last (0 or 1)
        // if (groups[i] == 0) f[i][0] = Max(words[i] + f[i-1][1], f[i-1][0]) and f[i][1] = f[i-1][1]
        // else f[i][1] = Max(words[i] + f[i-1][0], f[i-1][1]) and f[i][0] = f[i-1][0]
        // f[0][0] = f[0][1] = ""
        int n = groups.Length;
        List<string>[][] f = new List<string>[n + 1][];
        for (int i = 0; i <= n; i++) f[i] = new List<string>[2];
        f[0][0] = f[0][1] = [];
        for (int i = 1; i <= n; i++)
        {
            int last = groups[i - 1];
            if (f[i - 1][1 - last].Count + 1 > f[i - 1][last].Count)
            {
                f[i][last] = [.. f[i - 1][1 - last], words[i - 1]];
            }
            else
            {
                f[i][last] = [.. f[i - 1][last]];
            }

            f[i][1 - last] = [.. f[i - 1][1 - last]];
        }
        if (f[n][0].Count > f[n][1].Count) return f[n][0];
        return f[n][1];
    }
}