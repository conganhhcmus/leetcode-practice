#if DEBUG
namespace Weekly_449_Q2;
#endif

public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        long sum = 0;
        int n = grid.Length, m = grid[0].Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                sum += grid[i][j];
            }
        }
        if (sum % 2 != 0) return false;
        long target = sum / 2;
        long section = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                section += grid[i][j];
            }
            if (section == target) return true;
            if (section > target) break;
        }
        section = 0;
        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n; i++)
            {
                section += grid[i][j];
            }
            if (section == target) return true;
            if (section > target) break;
        }
        return false;
    }
}