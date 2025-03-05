#if DEBUG
namespace Contests_432_Q1;
#endif

public class Solution
{
    public IList<int> ZigzagTraversal(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        IList<int> ans = [];
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
                for (int j = 0; j < m; j += 2) ans.Add(grid[i][j]);
            else
                for (int j = m - 1 - (m & 1); j >= 0; j -= 2) ans.Add(grid[i][j]);
        }
        return ans;
    }
}