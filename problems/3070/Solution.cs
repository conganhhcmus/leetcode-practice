public class Solution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int[][] fn = new int[m][];
        for (int i = 0; i < m; i++)
        {
            fn[i] = new int[n];
        }

        int count = 0;

        fn[0][0] = grid[0][0];
        if (fn[0][0] <= k) count++;

        for (int i = 1; i < m; i++)
        {
            fn[i][0] = fn[i - 1][0] + grid[i][0];
            if (fn[i][0] <= k) count++;
        }

        for (int j = 1; j < n; j++)
        {
            fn[0][j] = fn[0][j - 1] + grid[0][j];
            if (fn[0][j] <= k) count++;
        }


        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                fn[i][j] = fn[i - 1][j] + fn[i][j - 1] - fn[i - 1][j - 1] + grid[i][j];
                if (fn[i][j] <= k) count++;
            }
        }

        return count;
    }
}