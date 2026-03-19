public class Solution
{
    public int NumberOfSubmatrices(char[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int[][] fn = new int[m][];
        bool[][] ok = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            fn[i] = new int[n];
            ok[i] = new bool[n];
        }
        fn[0][0] = Point(grid[0][0]);
        ok[0][0] = grid[0][0] == 'X';
        for (int i = 1; i < m; i++)
        {
            fn[i][0] = fn[i - 1][0] + Point(grid[i][0]);
            ok[i][0] = ok[i - 1][0] || (grid[i][0] == 'X');
        }
        for (int j = 1; j < n; j++)
        {
            fn[0][j] = fn[0][j - 1] + Point(grid[0][j]);
            ok[0][j] = ok[0][j - 1] || (grid[0][j] == 'X');
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                fn[i][j] = fn[i - 1][j] + fn[i][j - 1] - fn[i - 1][j - 1] + Point(grid[i][j]);
                ok[i][j] = ok[i - 1][j] || ok[i][j - 1] || (grid[i][j] == 'X');
            }
        }

        int count = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (fn[i][j] == 0 && ok[i][j]) count++;
            }
        }
        return count;
    }

    int Point(char c)
    {
        if (c == 'X') return 1;
        if (c == 'Y') return -1;
        return 0;
    }
}