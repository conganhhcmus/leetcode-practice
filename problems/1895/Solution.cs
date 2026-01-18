#if DEBUG
namespace Problems_1895;
#endif

public class Solution
{
    public int LargestMagicSquare(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        for (int k = Math.Min(n, m); k > 0; k--)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (IsMagicSquare(i, j, k, grid)) return k;
                }
            }
        }
        return 0;
    }

    bool IsMagicSquare(int x, int y, int k, int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        if (x + k > n || y + k > m) return false;
        long sum = 0;
        for (int i = x; i < x + k; i++)
        {
            for (int j = y; j < y + k; j++)
            {
                sum += grid[i][j];
            }
        }
        if (sum % k != 0) return false;
        long target = sum / k;
        // check row
        for (int i = x; i < x + k; i++)
        {
            sum = 0;
            for (int j = y; j < y + k; j++)
            {
                sum += grid[i][j];
            }
            if (sum != target) return false;
        }
        // check col
        for (int j = y; j < y + k; j++)
        {
            sum = 0;
            for (int i = x; i < x + k; i++)
            {
                sum += grid[i][j];
            }
            if (sum != target) return false;
        }
        // check dialog
        sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += grid[x + i][y + i];
        }
        if (sum != target) return false;
        sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += grid[x + i][y + k - 1 - i];
        }
        if (sum != target) return false;
        return true;
    }
}