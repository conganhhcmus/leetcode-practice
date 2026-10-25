public class Solution
{
    public int ClosedIsland(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        for (int i = 0; i < n; i++)
        {
            Dfs(i, 0);
            Dfs(i, m - 1);
        }
        for (int i = 0; i < m; i++)
        {
            Dfs(0, i);
            Dfs(n - 1, i);
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0)
                {
                    Dfs(i, j);
                    ans++;
                }
            }
        }
        return ans;

        void Dfs(int r, int c)
        {
            if (r < 0 || c < 0 || r >= n || c >= m || grid[r][c] != 0) return;

            grid[r][c] = 2;
            Dfs(r - 1, c);
            Dfs(r + 1, c);
            Dfs(r, c - 1);
            Dfs(r, c + 1);
        }
    }
}