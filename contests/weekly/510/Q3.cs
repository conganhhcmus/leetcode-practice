public class Solution
{
    public string[] CreateGrid(int m, int n, int k)
    {
        char[][] grid = new char[m][];
        for (int i = 0; i < m; i++)
        {
            grid[i] = new char[n];
            Array.Fill(grid[i], '.');
        }
        string[] ans = null;
        Dfs(0);
        return ans ?? [];

        int CountPaths()
        {
            int[,] dp = new int[m, n];
            if (grid[0][0] == '#') return 0;
            dp[0, 0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '#') continue;
                    if (i > 0) dp[i, j] += dp[i - 1, j];
                    if (j > 0) dp[i, j] += dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }

        void Dfs(int idx)
        {
            if (ans != null) return;
            long p = CountPaths();
            if (p == k)
            {
                ans = [.. grid.Select(a => new string(a))];
                return;
            }
            if (p < k) return;
            if (idx == m * n) return;
            int r = idx / n, c = idx % n;
            grid[r][c] = '#';
            Dfs(idx + 1);
            if (ans != null) return;
            grid[r][c] = '.';
            Dfs(idx + 1);
        }
    }
}
