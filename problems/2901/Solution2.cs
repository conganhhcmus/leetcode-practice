#if DEBUG
namespace Problems_2901_2;
#endif

public class Solution
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        int n = words.Length;
        int[] dp = new int[n];
        int[] prev = new int[n];
        Array.Fill(dp, 1);
        Array.Fill(prev, -1);
        int maxIndex = 0;
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (Check(words[i], words[j]) && dp[j] + 1 > dp[i] && groups[i] != groups[j])
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }
            if (dp[i] > dp[maxIndex]) maxIndex = i;
        }

        List<string> ret = [];
        for (int i = maxIndex; i >= 0; i = prev[i])
        {
            ret.Add(words[i]);
        }
        ret.Reverse();
        return ret;
    }

    bool Check(string a, string b)
    {
        if (a.Length != b.Length) return false;
        int diff = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i]) diff++;
            if (diff > 1) return false;
        }
        return diff == 1;
    }
}