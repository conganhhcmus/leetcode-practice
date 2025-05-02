#if DEBUG
namespace Problems_91;
#endif

public class Solution
{
    public int NumDecodings(string s)
    {
        // n = 100
        // dp[i] = numDecoding ending at i
        // dp[i] = dp[i-1] + (s[i]+s[i-1] <= '26') dp[i-2]
        int n = s.Length;
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = s[^1] == '0' ? 0 : 1;
        for (int i = 2; i <= n; i++)
        {
            int num = (s[^i] - '0') * 10 + (s[^(i - 1)] - '0');
            if (num == 0) return 0;
            if (num <= 26 && num >= 10)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            if (num > 26) dp[i] = dp[i - 1];
        }
        return dp[n];
    }
}