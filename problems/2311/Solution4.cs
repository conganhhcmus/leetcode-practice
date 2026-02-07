public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        int n = s.Length;
        char[] bits = s.ToCharArray();
        Array.Reverse(bits);
        Pair[] dp = new Pair[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new(bits[i] - '0', 1);
        }

        int ret = 1;
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (bits[i] == '1' && dp[j].Len <= 30 && (dp[j].Val | (1 << dp[j].Len)) <= k && dp[j].Len + 1 > dp[i].Len)
                {
                    dp[i] = new(dp[j].Val + (1 << dp[j].Len), dp[j].Len + 1);
                }
                else if (bits[i] == '0' && dp[j].Val <= k && dp[j].Len + 1 > dp[i].Len)
                {
                    dp[i] = new(dp[j].Val, dp[j].Len + 1);
                }
            }
            ret = Math.Max(ret, dp[i].Len);
        }

        return ret;
    }

    public record Pair(int Val, int Len);
}