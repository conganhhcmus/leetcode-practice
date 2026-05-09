public class Solution
{
    public int[][] RotateGrid(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int maxLayer = Math.Min(m / 2, n / 2);
        for (int layer = 0; layer < maxLayer; layer++)
        {
            List<int> cols = [], rows = [], vals = [];
            // top
            for (int i = layer; i < n - layer - 1; i++)
            {
                cols.Add(i);
                rows.Add(layer);
                vals.Add(grid[layer][i]);
            }
            // right
            for (int i = layer; i < m - layer - 1; i++)
            {
                cols.Add(n - layer - 1);
                rows.Add(i);
                vals.Add(grid[i][n - layer - 1]);
            }
            // bottom
            for (int i = n - layer - 1; i > layer; i--)
            {
                cols.Add(i);
                rows.Add(m - layer - 1);
                vals.Add(grid[m - layer - 1][i]);
            }
            // left
            for (int i = m - layer - 1; i > layer; i--)
            {
                cols.Add(layer);
                rows.Add(i);
                vals.Add(grid[i][layer]);
            }
            for (int i = 0; i < vals.Count; i++)
            {
                int idx = (i + k) % vals.Count;
                grid[rows[i]][cols[i]] = vals[idx];
            }
        }

        return grid;
    }
}
