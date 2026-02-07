public class Solution
{
    public int LongestValidParentheses(string s)
    {
        int n = s.Length;
        // dp[i] = longest valid from 0 with end s[i]

        int[] dp = new int[n + 1];
        int maxLen = 0;
        for (int i = 2; i <= n; i++)
        {
            if (s[i - 1] == ')')
            {
                if (s[i - 2] == '(')
                {
                    dp[i] = dp[i - 2] + 2;
                }
                else if (i - dp[i - 1] - 2 >= 0 && s[i - dp[i - 1] - 2] == '(')
                {
                    dp[i] = dp[i - 1] + 2;
                    if (i - dp[i] >= 0) dp[i] += dp[i - dp[i]];
                }
            }
            maxLen = Math.Max(maxLen, dp[i]);
        }
        return maxLen;
    }
}