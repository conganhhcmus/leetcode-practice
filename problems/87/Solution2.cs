public class Solution
{
    public bool IsScramble(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        int n = s1.Length;
        bool[,,] dp = new bool[n + 1, n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[1, i, j] = s1[i] == s2[j];
            }
        }
        for (int l = 2; l <= n; l++)
        {
            for (int i = 0; i + l <= n; i++)
            {
                for (int j = 0; j + l <= n; j++)
                {
                    for (int k = 1; k < l; k++)
                    {
                        if ((dp[k, i, j] && dp[l - k, i + k, j + k]) || (dp[k, i, j + l - k] && dp[l - k, i + k, j]))
                        {
                            dp[l, i, j] = true;
                            break;
                        }
                    }
                }
            }
        }
        return dp[n, 0, 0];
    }
}
