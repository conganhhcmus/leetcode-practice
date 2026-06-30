public class Solution
{
    public int MinInsertions(string s)
    {
        int n = s.Length;
        int[,] dp = new int[n, n];
        for (int i = 0; i < n; i++) dp[i, i] = 0;
        for (int d = 1; d < n; d++)
        {
            for (int i = 0; i < n; i++)
            {
                int j = i + d;
                if (j >= n) break;
                if (s[i] == s[j]) dp[i, j] = dp[i + 1, j - 1];
                else dp[i, j] = 1 + Math.Min(dp[i + 1, j], dp[i, j - 1]);
            }
        }

        return dp[0, n - 1];
    }
}
