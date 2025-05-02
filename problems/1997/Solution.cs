#if DEBUG
namespace Problems_1997;
#endif

public class Solution
{
    public int FirstDayBeenInAllRooms(int[] nextVisit)
    {
        // n = 10^5
        // dp[i] = first day been in room i
        // dp[i] = dp[i-1] + dp[i-1] - dp[next[i-1]] + 2;
        int n = nextVisit.Length;
        int mod = (int)1e9 + 7;
        int[] dp = new int[n];
        dp[0] = 0;
        dp[1] = 2;
        for (int i = 2; i < n; i++)
        {
            dp[i] = (2 * dp[i - 1] - dp[nextVisit[i - 1]] + 2) % mod;
            dp[i] = (dp[i] + mod) % mod; // resolve for negative number
        }

        return dp[n - 1];
    }
}