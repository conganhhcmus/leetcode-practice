public class Solution
{
    public int MinimumOR(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        bool[][] skip = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            skip[i] = new bool[n];
        }
        int ans = 0;
        for (int i = 31; i >= 0; i--)
        {
            int bit = 1 << i;
            if (!CanIgnore(skip, grid, bit))
            {
                ans |= bit;
            }
        }
        return ans;
    }

    bool CanIgnore(bool[][] skip, int[][] grid, int bit)
    {
        int m = grid.Length, n = grid[0].Length;
        for (int r = 0; r < m; r++)
        {
            // check each row
            bool can = false;
            for (int c = 0; c < n; c++)
            {
                if (skip[r][c]) continue;
                if ((grid[r][c] & bit) == 0)
                {
                    can = true;
                    break;
                }
            }
            if (!can) return false;
        }

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (skip[r][c]) continue;
                if ((grid[r][c] & bit) != 0)
                {
                    skip[r][c] = true;
                }
            }
        }
        return true;
    }
}