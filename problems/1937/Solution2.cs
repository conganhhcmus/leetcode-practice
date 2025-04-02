#if DEBUG
namespace Problems_1937_2;
#endif

public class Solution
{
    public long MaxPoints(int[][] points)
    {
        int n = points.Length, m = points[0].Length;
        long[][] memo = new long[n][];
        for (int i = 0; i < n; i++)
        {
            memo[i] = new long[m];
            Array.Fill(memo[i], -1);
        }
        long[] leftMax = new long[m];
        long[] rightMax = new long[m];

        long ans = 0;
        for (int i = 0; i < m; i++)
        {
            ans = Math.Max(ans, DP(points, n - 1, i, memo, leftMax, rightMax));
        }
        return ans;
    }

    long DP(int[][] points, int row, int col, long[][] memo, long[] leftMax, long[] rightMax)
    {
        int n = points.Length, m = points[0].Length;
        if (row <= 0) return memo[row][col] = points[0][col];
        if (memo[row][col] != -1) return memo[row][col];

        if (col == 0)
        {
            leftMax[0] = DP(points, row - 1, 0, memo, leftMax, rightMax);
            for (int i = 1; i < m; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1] - 1, DP(points, row - 1, i, memo, leftMax, rightMax));
            }
            rightMax[m - 1] = DP(points, row - 1, m - 1, memo, leftMax, rightMax);
            for (int i = m - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1] - 1, DP(points, row - 1, i, memo, leftMax, rightMax));
            }
        }

        long ans = points[row][col] + Math.Max(leftMax[col], rightMax[col]);
        memo[row][col] = ans;
        return ans;
    }
}