public class Solution
{
    public int NumDistinct(string s, string t)
    {
        int n = s.Length, m = t.Length;
        int[] dp = new int[m + 1];
        dp[0] = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = m; j > 0; j--)
            {
                dp[j] += s[i] == t[j - 1] ? dp[j - 1] : 0;
            }
        }

        return dp[m];
    }
}
