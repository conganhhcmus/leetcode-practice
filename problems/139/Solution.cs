#if DEBUG
namespace Problems_139;
#endif

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true;
        for (int i = 1; i <= n; i++)
        {
            foreach (string word in wordDict)
            {
                if (i >= word.Length)
                {
                    if (s.Substring(i - word.Length, word.Length) == word)
                    {
                        dp[i] = dp[i] || dp[i - word.Length];
                    }
                }
            }
        }
        return dp[n];
    }
}