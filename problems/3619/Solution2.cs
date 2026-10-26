public class Solution
{
    public int CountIslands(int[][] grid, int k)
    {
        int[] dirs = [1, 0, -1, 0, 1];
        int n = grid.Length, m = grid[0].Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] > 0 && Dfs(i, j) % k == 0) ans++;
            }
        }
        return ans;

        long Dfs(int i, int j)
        {
            long sum = grid[i][j];
            grid[i][j] = 0;
            for (int d = 0; d < 4; d++)
            {
                int x = i + dirs[d], y = j + dirs[d + 1];
                if (x >= 0 && x < n && y >= 0 && y < m && grid[x][y] > 0)
                {
                    sum += Dfs(x, y);
                }
            }
            return sum;
        }
    }
}