#if DEBUG
namespace Problems_2900_3;
#endif

public class Solution
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        int n = groups.Length;
        // f[i][last] is len of longest subsequence end is last (0 or 1)
        // if (groups[i] == 0) f[i][0] = Max(1 + f[i-1][1], f[i-1][0]) and f[i][1] = f[i-1][1]
        // else f[i][1] = Max(1 + f[i-1][0], f[i-1][1]) and f[i][0] = f[i-1][0]
        // f[0][0] = f[0][1] = 0
        int[][] f = new int[n + 1][];
        for (int i = 0; i <= n; i++) f[i] = new int[2];
        f[0][0] = f[0][1] = 0;
        for (int i = 1; i <= n; i++)
        {
            int last = groups[i - 1];
            f[i][last] = Math.Max(f[i - 1][1 - last] + 1, f[i - 1][last]);
            f[i][1 - last] = f[i - 1][1 - last];
        }
        List<string> ans = [];
        int curr = 0;
        for (int i = 1; i <= n; i++)
        {
            if (f[i][0] > curr || f[i][1] > curr)
            {
                ans.Add(words[i - 1]);
                curr++;
            }
        }
        return ans;
    }
}