#if DEBUG
namespace Problems_5;
#endif

public class Solution
{
    public string LongestPalindrome(string s)
    {
        int n = s.Length;
        int maxLen = 0;
        int left = 0;
        bool[,] dp = new bool[n, n];
        for (int i = 0; i < n; i++)
        {
            dp[i, i] = true;
            for (int j = 0; j < i; j++)
            {
                if (s[i] == s[j] && (i - j <= 2 || dp[j + 1, i - 1]))
                {
                    dp[j, i] = true;
                    if (i - j + 1 > maxLen)
                    {
                        maxLen = i - j + 1;
                        left = j;
                    }
                }
            }
        }

        return s.Substring(left, maxLen);
    }
}