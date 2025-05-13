#if DEBUG
namespace Weekly_449_Q4;
#endif

public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                sum += grid[i][j];
            }
        }
        long section = 0;
        bool[] seen = new bool[100001];
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < m; j++)
            {
                section += grid[i][j];
                seen[grid[i][j]] = true;
            }
            long diff = 2L * section - sum;
            if (diff < 0) continue;
            if (diff == 0) return true;
            if (i == 0)
            {
                if (diff < 100001 && (grid[i][0] == diff || grid[i][m - 1] == diff)) return true;
            }
            else
            {
                if (m == 1)
                {
                    if (diff < 100001 && (grid[0][0] == diff || grid[i][0] == diff)) return true;
                }
                else
                {
                    if (diff < 100001 && seen[diff]) return true;
                }
            }
        }
        section = 0;
        Array.Clear(seen);
        for (int i = n - 1; i > 0; i--)
        {
            for (int j = 0; j < m; j++)
            {
                section += grid[i][j];
                seen[grid[i][j]] = true;
            }
            long diff = 2L * section - sum;
            if (diff < 0) continue;
            if (diff == 0) return true;
            if (i == n - 1)
            {
                if (diff < 100001 && (grid[i][0] == diff || grid[i][m - 1] == diff)) return true;
            }
            else
            {
                if (m == 1)
                {
                    if (diff < 100001 && (grid[n - 1][0] == diff || grid[i][0] == diff)) return true;
                }
                else
                {
                    if (diff < 100001 && seen[diff]) return true;
                }
            }
        }
        section = 0;
        Array.Clear(seen);
        for (int j = 0; j < m - 1; j++)
        {
            for (int i = 0; i < n; i++)
            {
                section += grid[i][j];
                seen[grid[i][j]] = true;
            }
            long diff = 2L * section - sum;
            if (diff < 0) continue;
            if (diff == 0) return true;
            if (j == 0)
            {
                if (diff < 100001 && (grid[0][j] == diff || grid[n - 1][j] == diff)) return true;
            }
            else
            {
                if (n == 1)
                {
                    if (diff < 100001 && (grid[0][0] == diff || grid[0][j] == diff)) return true;
                }
                else
                {
                    if (diff < 100001 && seen[diff]) return true;
                }
            }
        }
        section = 0;
        Array.Clear(seen);
        for (int j = m - 1; j > 0; j--)
        {
            for (int i = 0; i < n; i++)
            {
                section += grid[i][j];
                seen[grid[i][j]] = true;
            }
            long diff = 2L * section - sum;
            if (diff < 0) continue;
            if (diff == 0) return true;
            if (j == m - 1)
            {
                if (diff < 100001 && (grid[0][j] == diff || grid[n - 1][j] == diff)) return true;
            }
            else
            {
                if (n == 1)
                {
                    if (diff < 100001 && (grid[0][m - 1] == diff || grid[0][j] == diff)) return true;
                }
                else
                {
                    if (diff < 100001 && seen[diff]) return true;
                }
            }
        }
        return false;
    }
}