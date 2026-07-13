public class Solution
{
    public int MaxConsistentColumns(int[][] grid, int limit)
    {
        int m = grid.Length, n = grid[0].Length;
        // grid[i][a] - grid[i][b] <= limit
        // a -> b: ok
        List<int>[] g = new List<int>[n];
        for (int a = 0; a < n; a++)
        {
            g[a] = [];
            for (int b = a + 1; b < n; b++)
            {
                bool isOk = true;
                for (int i = 0; i < m; i++)
                {
                    int diff = Math.Abs(grid[i][a] - grid[i][b]);
                    if (diff > limit)
                    {
                        isOk = false;
                        break;
                    }
                }
                if (isOk) g[a].Add(b);
            }
        }
        int ans = 0;
        int[] depth = new int[n];
        Array.Fill(depth, 1);
        for (int i = n - 1; i >= 0; i--)
        {
            foreach (int j in g[i])
            {
                depth[i] = Math.Max(depth[i], depth[j] + 1);
            }
        }
        for (int i = 0; i < n; i++)
        {
            ans = Math.Max(ans, depth[i]);
        }
        return ans;
    }
}
