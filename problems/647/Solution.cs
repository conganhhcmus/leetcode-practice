public class Solution
{
    public int CountSubstrings(string s)
    {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        for (int i = 0; i < n; i++) dp[i, i] = true;
        for (int i = 0; i < n - 1; i++) dp[i, i + 1] = s[i] == s[i + 1];
        for (int l = 2; l < n; l++)
        {
            for (int i = 0; i < n; i++)
            {
                int j = i + l;
                if (j >= n) break;
                if (s[i] == s[j]) dp[i, j] |= dp[i + 1, j - 1];
            }
        }
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (dp[i, j]) cnt++;
            }
        }
        return cnt;
    }
}
