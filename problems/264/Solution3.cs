#if DEBUG
namespace Problems_264_3;
#endif

public class Solution
{
    public int NthUglyNumber(int n)
    {
        // i-th Ugly Number  = 2^x * 2^y * 2^z
        // i+1-th Ugly Number  = Min of x+1, y+1,z+1
        int[] dp = new int[n + 1];
        dp[0] = 1;
        int p2 = 0, p3 = 0, p5 = 0;
        for (int i = 1; i < n; i++)
        {
            dp[i] = Math.Min(dp[p2] * 2, Math.Min(dp[p3] * 3, dp[p5] * 5));
            if (dp[i] == dp[p2] * 2) p2++;
            if (dp[i] == dp[p3] * 3) p3++;
            if (dp[i] == dp[p5] * 5) p5++;
        }
        return dp[n - 1];
    }
}