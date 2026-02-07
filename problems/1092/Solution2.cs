public class Solution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        int n = str1.Length, m = str2.Length;
        int[,] dp = new int[n + 1, m + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        int p1 = n, p2 = m;
        StringBuilder sb = new();
        while (p1 > 0 && p2 > 0)
        {
            if (str1[p1 - 1] == str2[p2 - 1])
            {
                sb.Append(str1[p1 - 1]);
                p1--;
                p2--;
            }
            else if (dp[p1, p2 - 1] < dp[p1 - 1, p2])
            {
                sb.Append(str1[p1 - 1]);
                p1--;
            }
            else
            {
                sb.Append(str2[p2 - 1]);
                p2--;
            }
        }

        while (p1 > 0)
        {
            sb.Append(str1[p1 - 1]);
            p1--;
        }
        while (p2 > 0)
        {
            sb.Append(str2[p2 - 1]);
            p2--;
        }

        char[] ans = sb.ToString().ToCharArray();
        Array.Reverse(ans);
        return new(ans);
    }
}