#if DEBUG
namespace Contests_432_Q2;
#endif

public class Solution
{
    public int MaximumAmount(int[][] coins)
    {
        int n = coins.Length, m = coins[0].Length;
        int[,,] dp = new int[n, m, 3];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    dp[i, j, k] = int.MinValue / 3;
                }
            }
        }

        dp[0, 0, 0] = coins[0][0];
        dp[0, 0, 1] = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (i > 0)
                    {
                        dp[i, j, k] = Math.Max(dp[i, j, k], dp[i - 1, j, k] + coins[i][j]);
                    }
                    if (j > 0)
                    {
                        dp[i, j, k] = Math.Max(dp[i, j, k], dp[i, j - 1, k] + coins[i][j]);
                    }

                    if (coins[i][j] < 0 && k < 2)
                    {
                        if (i > 0)
                        {
                            dp[i, j, k + 1] = Math.Max(dp[i, j, k + 1], dp[i - 1, j, k]);
                        }
                        if (j > 0)
                        {
                            dp[i, j, k + 1] = Math.Max(dp[i, j, k + 1], dp[i, j - 1, k]);
                        }
                    }
                }
            }
        }

        return Math.Max(dp[n - 1, m - 1, 0], Math.Max(dp[n - 1, m - 1, 1], dp[n - 1, m - 1, 2]));
    }
}