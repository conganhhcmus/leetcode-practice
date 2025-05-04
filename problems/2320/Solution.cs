#if DEBUG
namespace Problems_2320;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;

    public int CountHousePlacements(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 2;
        for (int i = 2; i <= n; i++)
        {
            dp[i] = (dp[i - 1] + dp[i - 2]) % mod;
        }

        return (int)(1L * dp[n] * dp[n] % mod);
    }
}