#if DEBUG
namespace Problems_1351_2;
#endif

public class Solution
{
    public int CountNegatives(int[][] grid)
    {
        int row = 0, col = grid[0].Length - 1;
        int ans = 0;
        while (row < grid.Length && col >= 0)
        {
            if (grid[row][col] < 0)
            {
                ans += grid.Length - row;
                col--;
            }
            else
            {
                row++;
            }
        }
        return ans;
    }
}