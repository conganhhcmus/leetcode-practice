public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[n + 1];
            if (i > 0) Array.Fill(dp[i], int.MaxValue);
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                dp[i][j] = triangle[i - 1][j - 1] + Math.Min(dp[i - 1][j], dp[i - 1][j - 1]);
            }
        }
        int min = int.MaxValue;
        for (int i = 1; i <= n; i++)
        {
            min = Math.Min(min, dp[n][i]);
        }
        return min;
    }
}