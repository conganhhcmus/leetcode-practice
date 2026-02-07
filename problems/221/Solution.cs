public class Solution
{
    public int MaximalSquare(char[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int[,] dp = new int[m, n];
        int max = 0;
        for (int i = 0; i < m; i++)
        {
            dp[i, 0] = matrix[i][0] - '0';
            max = Math.Max(max, dp[i, 0]);
        }
        for (int j = 0; j < n; j++)
        {
            dp[0, j] = matrix[0][j] - '0';
            max = Math.Max(max, dp[0, j]);
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][j] == '1')
                {
                    int x = Math.Min(dp[i, j - 1], dp[i - 1, j]);
                    dp[i, j] = x + matrix[i - x][j - x] - '0';
                    max = Math.Max(max, dp[i, j]);
                }
            }
        }

        return max * max;
    }
}