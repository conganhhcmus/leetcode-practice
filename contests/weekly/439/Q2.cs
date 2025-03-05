#if DEBUG
namespace Contests_439_Q2;
#endif

public class Solution
{
    public int LongestPalindromicSubsequence(string s, int k)
    {
        int n = s.Length;
        int[,,] dp = new int[n, n, k + 1];
        // dp[i,j,k] is the length of longest palindromic sequence int substring [i..j] with cost at most k
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= k; j++)
            {
                dp[i, i, j] = 1;
            }
        }

        for (int len = 2; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                for (int t = 0; t <= k; t++)
                {
                    if (s[i] == s[j])
                    {
                        dp[i, j, t] = 2 + dp[i + 1, j - 1, t];
                    }
                    else
                    {
                        int num1 = dp[i + 1, j, t];
                        int num2 = dp[i, j - 1, t];
                        int c = MinDistance(s[i], s[j]);
                        int num3 = (t >= c) ? 2 + dp[i + 1, j - 1, t - c] : 0;
                        dp[i, j, t] = Math.Max(Math.Max(num1, num2), num3);
                    }
                }
            }
        }
        return dp[0, n - 1, k];
    }

    private int MinDistance(char a, char b)
    {
        int diffNext = Math.Abs(a - b);
        int diffPrev = Math.Abs(26 - diffNext);
        return Math.Min(diffNext, diffPrev);
    }
}