#if DEBUG
namespace Contests_430_Q1;
#endif

public class Solution
{
    public int MinimumOperations(int[][] grid)
    {
        int ans = 0;
        int col = grid[0].Length, row = grid.Length;
        for (int i = 0; i < col; i++)
        {
            int prev = grid[0][i];
            for (int j = 1; j < row; j++)
            {
                if (grid[j][i] <= prev)
                {
                    int increase = prev - grid[j][i] + 1;
                    ans += increase;
                    grid[j][i] += increase;
                }
                prev = grid[j][i];
            }
        }
        return ans;
    }
}