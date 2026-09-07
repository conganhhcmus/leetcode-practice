public class Solution
{
    public int DistinctSubseqII(string s)
    {
        // dp[i] = number of subsequeue s[..i]
        // if s[i] is distinct from all previous char, dp[i] = 2 * dp[i-1] + 1
        // mean skip s[i], add s[i] and only s[i] char = dp[i-1] + dp[i-1] + 1
        // if s[i] appeared at least once, dp[i] = 2 * dp[i-1] - repetition
        // repetition is dp[j-1] where j is last time char s[i] shows 
        int n = s.Length;
        int mod = (int)1e9 + 7;
        long[] dp = new long[n + 1];
        int[] last = new int[26];
        Array.Fill(last, -1);
        for (int i = 1; i <= n; i++)
        {
            int idx = s[i - 1] - 'a';
            if (last[idx] == -1)
            {
                dp[i] = (2L * dp[i - 1] + 1) % mod;
            }
            else
            {
                dp[i] = (2L * dp[i - 1] - dp[last[idx]] + mod) % mod;
            }
            last[idx] = i - 1;
        }
        return (int)dp[n];
    }
}
