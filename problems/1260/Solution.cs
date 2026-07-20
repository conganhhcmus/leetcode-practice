public class Solution
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int sz = m * n;
        int[][] ans = new int[m][];
        for (int i = 0; i < m; i++) ans[i] = new int[n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int idx = (i * n + j + k) % sz;
                int r = idx / n;
                int c = idx % n;
                ans[r][c] = grid[i][j];
            }
        }
        return ans;
    }
}
