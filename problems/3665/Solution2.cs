public class Solution
{
    public int UniquePaths(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int MOD = (int)1e9 + 7;
        // f[i][j][0] : enter (i, j) by moving down
        // f[i][j][1] : enter (i, j) by moving right
        int[,,] f = new int[m, n, 2];
        f[0, 0, 0] = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i > 0) // move down
                {
                    if (grid[i - 1][j] == 0)
                    {
                        f[i, j, 0] = (f[i - 1, j, 0] + f[i - 1, j, 1]) % MOD;
                    }
                    else
                    {
                        f[i, j, 0] = f[i - 1, j, 1];
                    }
                }

                if (j > 0) // move right
                {
                    if (grid[i][j - 1] == 0)
                    {
                        f[i, j, 1] = (f[i, j - 1, 0] + f[i, j - 1, 1]) % MOD;
                    }
                    else
                    {
                        f[i, j, 1] = f[i, j - 1, 0];
                    }
                }
            }
        }

        return (f[m - 1, n - 1, 0] + f[m - 1, n - 1, 1]) % MOD;
    }
}