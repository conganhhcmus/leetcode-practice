#if DEBUG
namespace Problems_2435_2;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;

    public int NumberOfPaths(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        long[][][] dp = new long[m + 1][][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new long[n + 1][];
            for (int j = 0; j <= n; j++)
            {
                dp[i][j] = new long[k];
            }
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == 1 && j == 1)
                {
                    dp[i][j][grid[0][0] % k] = 1;
                    continue;
                }
                int value = grid[i - 1][j - 1] % k;
                for (int r = 0; r < k; r++)
                {
                    int prevMod = (r - value + k) % k;
                    dp[i][j][r] = (dp[i - 1][j][prevMod] + dp[i][j - 1][prevMod]) % mod;
                }
            }
        }

        return (int)dp[m][n][0];
    }
}