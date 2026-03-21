public class Solution
{
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < k / 2; i++)
        {
            for (int j = 0; j < k; j++)
            {
                (grid[x + i][y + j], grid[x + k - i - 1][y + j]) = (grid[x + k - i - 1][y + j], grid[x + i][y + j]);
            }
        }
        return grid;
    }
}