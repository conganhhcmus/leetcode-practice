public class Solution
{
    public int MinCost(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        bool[][] dp = new bool[n][];
        for (int j = 0; j < n; j++)
        {
            dp[j] = new bool[1024];
        }
        dp[0][grid[0][0]] = true;
        for (int j = 1; j < n; j++)
        {
            int val = grid[0][j];
            for (int v = 0; v < 1024; v++)
            {
                if (dp[j - 1][v])
                {
                    dp[j][v ^ val] = true;
                }
            }
        }

        for (int i = 1; i < m; i++)
        {
            bool[][] nDp = new bool[n][];
            for (int j = 0; j < n; j++)
            {
                nDp[j] = new bool[1024];
            }
            for (int j = 0; j < n; j++)
            {
                int val = grid[i][j];
                for (int v = 0; v < 1024; v++)
                {
                    if (dp[j][v] || (j > 0 && nDp[j - 1][v]))
                    {
                        nDp[j][v ^ val] = true;
                    }
                }
            }

            dp = nDp;
        }

        for (int i = 0; i < 1024; i++)
        {
            if (dp[n - 1][i]) return i;
        }
        return -1;
    }
}