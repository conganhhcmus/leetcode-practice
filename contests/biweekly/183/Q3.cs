public class Solution
{
    public int MaxScore(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int INF = 1 << 30;
        int ans = -INF;
        // single cell
        for (int i = 1; i < m - 1; i++)
        {
            for (int j = 1; j < n - 1; j++)
            {
                ans = Math.Max(ans, grid[i][j]);
            }
        }
        // horizontal
        for (int i = 0; i < m; i++)
        {
            int f = grid[i][0];
            for (int j = 1; j < n; j++)
            {
                ans = Math.Max(ans, f + grid[i][j]);
                f = Math.Max(grid[i][j], f + grid[i][j]);
            }
        }
        // vertical
        for (int i = 0; i < n; i++)
        {
            int f = grid[0][i];
            for (int j = 1; j < m; j++)
            {
                ans = Math.Max(ans, f + grid[j][i]);
                f = Math.Max(grid[j][i], f + grid[j][i]);
            }
        }
        return ans;
    }
}
