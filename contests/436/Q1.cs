#if DEBUG
namespace Contests_436_Q1;
#endif

public class Solution
{
    public int[][] SortMatrix(int[][] grid)
    {
        int n = grid.Length;

        // diagonals bottom-left
        for (int i = 0; i < n; i++)
        {
            List<int> diagonals = new List<int>();
            for (int j = 0; i + j < n; j++)
            {
                diagonals.Add(grid[i + j][j]);
            }

            diagonals.Sort((a, b) => b - a);
            for (int j = 0; i + j < n; j++)
            {
                grid[i + j][j] = diagonals[j];
            }
        }

        // diagonals top-right
        for (int i = 1; i < n; i++)
        {
            List<int> diagonals = new List<int>();
            for (int j = 0; i + j < n; j++)
            {
                diagonals.Add(grid[j][i + j]);
            }

            diagonals.Sort((a, b) => a - b);
            for (int j = 0; i + j < n; j++)
            {
                grid[j][i + j] = diagonals[j];
            }
        }

        return grid;
    }
}