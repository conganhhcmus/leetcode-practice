public class Solution
{
    public int MaxProductPath(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int mod = (int)1e9 + 7;
        long[][] maxFn = new long[m][];
        long[][] minFn = new long[m][];
        for (int i = 0; i < m; i++)
        {
            maxFn[i] = new long[n];
            minFn[i] = new long[n];
        }
        maxFn[0][0] = minFn[0][0] = grid[0][0];

        for (int i = 1; i < m; i++)
        {
            maxFn[i][0] = Math.Max(maxFn[i - 1][0] * grid[i][0], minFn[i - 1][0] * grid[i][0]);
            minFn[i][0] = Math.Min(maxFn[i - 1][0] * grid[i][0], minFn[i - 1][0] * grid[i][0]);
        }

        for (int j = 1; j < n; j++)
        {
            maxFn[0][j] = Math.Max(maxFn[0][j - 1] * grid[0][j], minFn[0][j - 1] * grid[0][j]);
            minFn[0][j] = Math.Min(maxFn[0][j - 1] * grid[0][j], minFn[0][j - 1] * grid[0][j]);
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                maxFn[i][j] = Math.Max(
                    Math.Max(minFn[i - 1][j] * grid[i][j], minFn[i][j - 1] * grid[i][j]),
                    Math.Max(maxFn[i - 1][j] * grid[i][j], maxFn[i][j - 1] * grid[i][j])
                );

                minFn[i][j] = Math.Min(
                    Math.Min(minFn[i - 1][j] * grid[i][j], minFn[i][j - 1] * grid[i][j]),
                    Math.Min(maxFn[i - 1][j] * grid[i][j], maxFn[i][j - 1] * grid[i][j])
                );
            }
        }

        if (maxFn[m - 1][n - 1] < 0) return -1;

        return (int)(maxFn[m - 1][n - 1] % mod);
    }
}