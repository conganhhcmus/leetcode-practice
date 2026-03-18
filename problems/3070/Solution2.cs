public class Solution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int[] cols = new int[n];
        int count = 0;
        for (int i = 0; i < m; i++)
        {
            int row = 0;
            for (int j = 0; j < n; j++)
            {
                cols[j] += grid[i][j];
                row += cols[j];
                if (row <= k) count++;
            }
        }
        return count;
    }
}