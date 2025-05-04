#if DEBUG
namespace Problems_343_3;
#endif

public class Solution
{
    public int IntegerBreak(int n)
    {
        int[] dp = new int[n + 1];
        dp[2] = 1;
        for (int i = 3; i <= n; i++)
        {
            for (int j = 1; j < i - 1; j++)
            {
                dp[i] = Math.Max(dp[i], Math.Max(dp[i - j] * j, (i - j) * j));
            }
        }
        return dp[n];
    }
}