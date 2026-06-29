public class Solution
{
    public int LongestPalindromeSubseq(string s)
    {
        int n = s.Length;
        int[,] dp = new int[n, n];
        for (int i = 0; i < n; i++) dp[i, i] = 1;
        for (int l = 1; l < n; l++)
        {
            for (int i = 0; i < n; i++)
            {
                int j = i + l;
                if (j >= n) break;
                dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                if (s[i] == s[j]) dp[i, j] = Math.Max(dp[i, j], dp[i + 1, j - 1] + 2);
            }
        }
        return dp[0, n - 1];
    }
}
