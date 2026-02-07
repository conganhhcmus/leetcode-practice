public class Solution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        //key: str1 + str2 - LCS(longest common subsequence)
        int n = str1.Length, m = str2.Length;
        string[,] dp = new string[n + 1, m + 1];
        dp[0, 0] = "";
        for (int i = 1; i <= n; i++) dp[i, 0] = "";
        for (int j = 1; j <= m; j++) dp[0, j] = "";
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + str1[i - 1];
                }
                else
                {
                    dp[i, j] = dp[i - 1, j].Length > dp[i, j - 1].Length ? dp[i - 1, j] : dp[i, j - 1];
                }
            }
        }

        string lcs = dp[n, m];
        StringBuilder sb = new();
        int idx = 0, p1 = 0, p2 = 0;
        while (idx < lcs.Length)
        {
            while (p1 < n && str1[p1] != lcs[idx])
            {
                sb.Append(str1[p1]);
                p1++;
            }
            while (p2 < m && str2[p2] != lcs[idx])
            {
                sb.Append(str2[p2]);
                p2++;
            }
            sb.Append(lcs[idx]);
            idx++;
            p1++;
            p2++;
        }
        while (p1 < n) sb.Append(str1[p1++]);
        while (p2 < m) sb.Append(str2[p2++]);
        return sb.ToString();
    }
}