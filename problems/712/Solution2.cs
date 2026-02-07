public class Solution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        int sum1 = 0, sum2 = 0;
        foreach (char c in s1)
        {
            sum1 += c;
        }
        foreach (char c in s2)
        {
            sum2 += c;
        }
        int n = s1.Length, m = s2.Length;
        int[,] dp = new int[n + 1, m + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 2 * s1[i - 1];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return sum1 + sum2 - dp[n, m];
    }
}