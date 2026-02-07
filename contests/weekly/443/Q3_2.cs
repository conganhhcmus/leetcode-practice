public class Solution
{
    public int LongestPalindrome(string s, string t)
    {
        int n1 = s.Length, n2 = t.Length;
        // Let dp[i][j] be the length of the longest answer if we try starting it with s[i] and ending it with t[j].
        int[][] dp = new int[n1][];
        for (int i = 0; i < n1; i++) dp[i] = new int[n2];
        // let p[i] be the length of the longest palindrome substring start at i in s
        int[] p = LpsStart(s);

        // let q[i] be the length of the longest palindrome substring end at i in t
        int[] q = LpsEnd(t);
        int ret = 0;
        for (int i = n1 - 1; i >= 0; i--)
        {
            for (int j = 0; j < n2; j++)
            {
                dp[i][j] = Math.Max(p[i], q[j]);
                if (s[i] == t[j])
                {
                    if (i + 1 < n1 && j - 1 >= 0)
                    {
                        dp[i][j] = Math.Max(dp[i][j], 2 + dp[i + 1][j - 1]);
                    }
                    else if (i + 1 < n1)
                    {
                        dp[i][j] = Math.Max(dp[i][j], 2 + p[i + 1]);
                    }
                    else if (j - 1 >= 0)
                    {
                        dp[i][j] = Math.Max(dp[i][j], 2 + q[j - 1]);
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i][j], 2);
                    }
                }
                ret = Math.Max(ret, dp[i][j]);
            }
        }

        return ret;
    }

    int[] LpsEnd(string s)
    {
        int n = s.Length;
        int[] dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = Math.Max(dp[i], 1);
            int len = Expand(s, i, i);
            dp[i + len] = Math.Max(dp[i + len], len * 2 + 1);
            len = Expand(s, i - 1, i);
            if (len >= 0)
            {
                dp[i + len] = Math.Max(dp[i + len], len * 2 + 2);
            }
        }
        return dp;
    }

    int[] LpsStart(string s)
    {
        int n = s.Length;
        int[] dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = Math.Max(dp[i], 1);
            int len = Expand(s, i, i);
            dp[i - len] = Math.Max(dp[i - len], len * 2 + 1);
            len = Expand(s, i, i + 1);
            if (len >= 0)
            {
                dp[i - len] = Math.Max(dp[i - len], len * 2 + 2);
            }
        }
        return dp;
    }

    int Expand(string s, int start, int end)
    {
        int n = s.Length;
        int count = 0;
        while (start >= 0 && end < n && s[start] == s[end])
        {
            count++;
            start--;
            end++;
        }
        return count - 1;
    }
}