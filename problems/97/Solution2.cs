public class Solution
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        int m = s1.Length, n = s2.Length;

        if (m + n != s3.Length) return false;

        bool[] dp = new bool[n + 1];

        // base case
        dp[0] = true;

        // first row (i = 0)
        for (int j = 1; j <= n; j++)
        {
            dp[j] = dp[j - 1] && s2[j - 1] == s3[j - 1];
        }

        // fill DP
        for (int i = 1; i <= m; i++)
        {
            // first column (j = 0)
            dp[0] = dp[0] && s1[i - 1] == s3[i - 1];

            for (int j = 1; j <= n; j++)
            {
                dp[j] = (dp[j] && s1[i - 1] == s3[i + j - 1]) || (dp[j - 1] && s2[j - 1] == s3[i + j - 1]);
            }
        }

        return dp[n];
    }
}
