#if DEBUG
namespace Problems_3195;
#endif

public class Solution
{
    public int MinimumArea(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int min_i = m, max_i = 0, min_j = n, max_j = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    min_i = Math.Min(min_i, i);
                    max_i = Math.Max(max_i, i);
                    min_j = Math.Min(min_j, j);
                    max_j = Math.Max(max_j, j);
                }
            }
        }

        return (max_i - min_i + 1) * (max_j - min_j + 1);
    }
}