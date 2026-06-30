public class Solution
{
    public int CountPalindromicSubsequences(string s)
    {
        int n = s.Length;
        int MOD = 1_000_000_007;
        long[,] dp = new long[n, n];
        int[] next = new int[n]; // nearest right pos with same character
        int[] prev = new int[n]; // nearest left pos with same character
        Dictionary<char, int> map = [];
        for (int i = 0; i < n; i++)
        {
            prev[i] = map.GetValueOrDefault(s[i], -1);
            map[s[i]] = i;
        }
        map = [];
        for (int i = n - 1; i >= 0; i--)
        {
            next[i] = map.GetValueOrDefault(s[i], n);
            map[s[i]] = i;
        }
        for (int i = 0; i < n; i++) dp[i, i] = 1;
        for (int d = 1; d < n; d++)
        {
            for (int i = 0; i < n; i++)
            {
                int j = i + d;
                if (j >= n) break;
                if (s[i] != s[j])
                {
                    dp[i, j] = (dp[i + 1, j] + dp[i, j - 1] - dp[i + 1, j - 1]) % MOD;
                }
                else
                {
                    int L = next[i], R = prev[j];
                    if (L > R)
                    {
                        // no s[i] contain [i+1, j-1]
                        dp[i, j] = (2 * dp[i + 1, j - 1] + 2) % MOD;
                    }
                    else if (L == R)
                    {
                        // exacly one s[i] contain [i+1,j-1]
                        dp[i, j] = (2 * dp[i + 1, j - 1] + 1) % MOD;
                    }
                    else
                    {
                        dp[i, j] = (2 * dp[i + 1, j - 1] - dp[L + 1, R - 1]) % MOD;
                    }
                }
                if (dp[i, j] < 0) dp[i, j] += MOD;
            }
        }
        return (int)dp[0, n - 1];
    }
}
