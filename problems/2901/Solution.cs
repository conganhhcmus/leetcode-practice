#if DEBUG
namespace Problems_2901;
#endif

public class Solution
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        int n = words.Length;
        if (n < 2) return [.. words];
        IList<string> ret = [];
        IList<string>[] mapWords = new IList<string>[11];
        IList<int>[] mapGroups = new IList<int>[11];
        for (int i = 0; i < 11; i++)
        {
            mapGroups[i] = [];
            mapWords[i] = [];
        }
        for (int i = 0; i < n; i++)
        {
            int key = words[i].Length;
            mapWords[key].Add(words[i]);
            mapGroups[key].Add(groups[i]);
        }
        for (int i = 0; i < 11; i++)
        {
            IList<string> curr = DP(mapWords[i], mapGroups[i]);
            if (ret.Count < curr.Count) ret = curr;
        }
        return ret;
    }

    IList<string> DP(IList<string> words, IList<int> groups)
    {
        int n = words.Count;
        if (n < 2) return words;
        // dp[i] = longest subsequence end at i
        IList<string>[] dp = new IList<string>[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = [];
        }
        dp[0].Add(words[0]);
        IList<string> ret = dp[0];
        for (int i = 1; i < n; i++)
        {
            dp[i].Add(words[i]);
            for (int j = 0; j < i; j++)
            {
                if (groups[i] != groups[j] && GetHammingDistance(words[i], words[j]) == 1 && dp[i].Count < dp[j].Count + 1)
                {
                    dp[i] = [.. dp[j], words[i]];
                }
            }

            if (ret.Count < dp[i].Count) ret = dp[i];
        }

        return ret;
    }

    int GetHammingDistance(string a, string b)
    {
        int diff = 0;
        int n = a.Length, m = b.Length;
        if (n != m) throw new Exception("Cannot compute hamming distance");
        for (int i = 0; i < n; i++)
        {
            if (a[i] != b[i]) diff++;
        }
        return diff;
    }
}