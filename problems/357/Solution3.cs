#if DEBUG
namespace Problems_357_3;
#endif

public class Solution
{
    public int CountNumbersWithUniqueDigits(int n)
    {
        if (n == 0) return 1;
        if (n == 1) return 10;
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 9;
        int ret = dp[0] + dp[1];
        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] * (10 - (i - 1)); // 10 ways [0..9] exclude (i-1) first digits
            ret += dp[i];
        }
        return ret;
    }
}