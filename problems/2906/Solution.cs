public class Solution
{
    public int[][] ConstructProductMatrix(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int mod = 12345;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                grid[i][j] %= mod;
            }
        }
        int[][] ans = new int[n][];
        for (int i = 0; i < n; i++)
        {
            ans[i] = new int[m];
            Array.Fill(ans[i], 1);
        }

        // fill head
        int p1 = 1;
        for (int i = 0; i < n; i++)
        {
            int p2 = 1;
            for (int j = 0; j < m; j++)
            {
                ans[i][j] = ans[i][j] * p1 % mod;
                p2 = p2 * grid[i][j] % mod;
            }
            p1 = p1 * p2 % mod;
        }

        // fill tail
        p1 = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            int p2 = 1;
            for (int j = 0; j < m; j++)
            {
                ans[i][j] = ans[i][j] * p1 % mod;
                p2 = p2 * grid[i][j] % mod;
            }
            p1 = p1 * p2 % mod;
        }

        // fill left
        for (int i = 0; i < n; i++)
        {
            int p2 = 1;
            for (int j = 0; j < m; j++)
            {
                ans[i][j] = ans[i][j] * p2 % mod;
                p2 = p2 * grid[i][j] % mod;
            }
        }

        // fill right
        for (int i = 0; i < n; i++)
        {
            int p2 = 1;
            for (int j = m - 1; j >= 0; j--)
            {
                ans[i][j] = ans[i][j] * p2 % mod;
                p2 = p2 * grid[i][j] % mod;
            }
        }
        return ans;
    }
}