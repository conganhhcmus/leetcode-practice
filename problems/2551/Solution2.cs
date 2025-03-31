#if DEBUG
namespace Problems_2551_2;
#endif

public class Solution
{
    // TLE O(n*k) 1<=k<=n<=10^5 ~ O(n^2)
    public long PutMarbles(int[] weights, int k)
    {
        long max = FindMaximum(weights, k);
        long min = FindMinimum(weights, k);
        return max - min;
    }

    long FindMinimum(int[] weights, int k)
    {
        int n = weights.Length;
        long[] dp = new long[n + 1];
        Array.Fill(dp, long.MaxValue / 3);
        dp[0] = 0;

        for (int i = 1; i <= k; i++)
        {
            long min = long.MaxValue / 3;
            long[] tmp = new long[n + 1];
            Array.Fill(tmp, long.MaxValue / 3);
            for (int j = 1; j <= n; j++)
            {
                min = Math.Min(min, dp[j - 1] + weights[j - 1]);
                tmp[j] = min + weights[j - 1];
            }
            Array.Copy(tmp, dp, n + 1);
        }

        return dp[n];
    }

    long FindMaximum(int[] weights, int k)
    {
        int n = weights.Length;
        long[] dp = new long[n + 1];
        Array.Fill(dp, long.MinValue / 3);
        dp[0] = 0;

        for (int i = 1; i <= k; i++)
        {
            long max = long.MinValue / 3;
            long[] tmp = new long[n + 1];
            Array.Fill(tmp, long.MinValue / 3);
            for (int j = 1; j <= n; j++)
            {
                max = Math.Max(max, dp[j - 1] + weights[j - 1]);
                tmp[j] = max + weights[j - 1];
            }

            Array.Copy(tmp, dp, n + 1);
        }

        return dp[n];
    }
}