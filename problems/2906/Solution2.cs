public class Solution
{
    public int[][] ConstructProductMatrix(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int mod = 12345;
        int[][] p = new int[n][];
        for (int i = 0; i < n; i++)
        {
            p[i] = new int[m];
            Array.Fill(p[i], 1);
        }

        int prefix = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                grid[i][j] %= mod;
                p[i][j] = p[i][j] * prefix % mod;
                prefix = prefix * grid[i][j] % mod;
            }
        }

        int suffix = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                p[i][j] = p[i][j] * suffix % mod;
                suffix = suffix * grid[i][j] % mod;
            }
        }

        return p;
    }
}