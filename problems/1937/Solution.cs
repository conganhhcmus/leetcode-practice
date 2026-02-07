public class Solution
{
    public long MaxPoints(int[][] points)
    {
        int n = points.Length, m = points[0].Length;
        long[][] dp = new long[n][];
        // dp[i][j] = max point if pick points[i][j]
        // dp[i][j] = max of (points[i][j] - abs(j-x) + dp[i-1][x]);
        // dp[i][j] = max of (points[i][j] - j + dp[i-1][x] + x) if j >= x
        // dp[i][j] = max of (points[i][j] + j + dp[i-1][x] - x) if j <= x

        for (int i = 0; i < n; i++)
        {
            dp[i] = new long[m];
        }

        for (int j = 0; j < m; j++)
        {
            dp[0][j] = points[0][j];
        }

        for (int i = 1; i < n; i++)
        {
            long[] leftMax = new long[m];
            long[] rightMax = new long[m];

            leftMax[0] = dp[i - 1][0];
            for (int j = 1; j < m; j++)
            {
                leftMax[j] = Math.Max(leftMax[j - 1] - 1, dp[i - 1][j]);
            }

            rightMax[m - 1] = dp[i - 1][m - 1];
            for (int j = m - 2; j >= 0; j--)
            {
                rightMax[j] = Math.Max(rightMax[j + 1] - 1, dp[i - 1][j]);
            }

            for (int j = 0; j < m; j++)
            {
                dp[i][j] = points[i][j] + Math.Max(leftMax[j], rightMax[j]);
            }
        }

        long ans = 0;
        for (int j = 0; j < m; j++)
        {
            ans = Math.Max(ans, dp[n - 1][j]);
        }

        return ans;
    }
}