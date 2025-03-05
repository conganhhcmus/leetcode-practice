#if DEBUG
namespace Contests_439_Q3;
#endif

public class Solution
{
    public int MaxSum(int[] nums, int k, int m)
    {
        int n = nums.Length;
        int[] prefixSum = new int[n + 1];
        for (int i = 0; i < n; i++) prefixSum[i + 1] = prefixSum[i] + nums[i];

        int[,] dp = new int[k + 1, n + 1]; // dp[i,j] = max sum of i subarray with first j elements
        for (int i = 0; i <= k; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                dp[i, j] = (i == 0) ? 0 : int.MinValue;
            }
        }

        for (int i = 1; i <= k; i++)
        {
            int best = int.MinValue;
            for (int end = i * m; end <= n; end++)
            {
                int start = end - m;
                best = Math.Max(best, dp[i - 1, start] - prefixSum[start]);
                dp[i, end] = Math.Max(dp[i, end - 1], prefixSum[end] + best);
            }
        }

        return dp[k, n];
    }
}