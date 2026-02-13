public class Solution
{
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        int n = nums1.Length;
        int m = nums2.Length;
        long[,,] dp = new long[n + 1, m + 1, k + 1];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                dp[i, j, 0] = 0;
                for (int t = 1; t <= k; t++)
                {
                    dp[i, j, t] = long.MinValue / 2;
                }
            }
        }
        // dp[i,j,k] = max score of k pairs
        for (int t = 1; t <= k; t++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    dp[i, j, t] = Math.Max(dp[i - 1, j - 1, t - 1] + 1L * nums1[i - 1] * nums2[j - 1], Math.Max(dp[i - 1, j, t], dp[i, j - 1, t]));
                }
            }
        }

        return dp[n, m, k];
    }
}