#if DEBUG
namespace Problems_264;
#endif

public class Solution
{
    public int NthUglyNumber(int n)
    {
        // prime factor of 2,3,5
        // freq[2] = x, freq[3] = y, freq[5] = n - x - y
        // n-th UglyNumber = 2^x * 3^y * 5^k where x+y+k=n-1
        // dp[i] = i-th Ugly Number
        // dp[i] = Min of dp[j]*2,3,5 where j<i
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 1;
        dp[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] * 2L < int.MaxValue && dp[j] * 2 > dp[i - 1])
                {
                    dp[i] = Math.Min(dp[i], dp[j] * 2);
                }
                if (dp[j] * 3L < int.MaxValue && dp[j] * 3 > dp[i - 1])
                {
                    dp[i] = Math.Min(dp[i], dp[j] * 3);
                }
                if (dp[j] * 5L < int.MaxValue && dp[j] * 5 > dp[i - 1])
                {
                    dp[i] = Math.Min(dp[i], dp[j] * 5);
                }
            }
        }

        return dp[n];
    }
}