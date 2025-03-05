#if DEBUG
namespace Contests_433_Q3;
#endif

public class Solution
{
    public long MinCost(int n, int[][] cost)
    {
        // // Solution 1
        // int[][] qwe = [[0, 1], [0, 2], [1, 0], [1, 2], [2, 0], [2, 1]];
        // // group (0, n-1), (1, n-2), (2, n-3), ...
        // bool[,] can = new bool[6, 6];
        // for (int p1 = 0; p1 < 6; p1++)
        // {
        //     for (int p2 = 0; p2 < 6; p2++)
        //     {
        //         int x1 = qwe[p1][0];
        //         int y1 = qwe[p1][1];
        //         int x2 = qwe[p2][0];
        //         int y2 = qwe[p2][1];
        //         if (x1 != x2 && y1 != y2)
        //         {
        //             can[p1, p2] = true;
        //         }
        //     }
        // }

        // int m = n / 2;
        // long[,] dp = new long[m, 6];
        // for (int p = 0; p < 6; p++)
        // {
        //     int x = qwe[p][0];
        //     int y = qwe[p][1];
        //     dp[0, p] = cost[0][x] + cost[n - 1][y];
        // }
        // for (int i = 1; i < m; i++)
        // {
        //     for (int p = 0; p < 6; p++)
        //     {
        //         dp[i, p] = long.MaxValue;
        //     }
        // }

        // for (int i = 1; i < m; i++)
        // {
        //     for (int p1 = 0; p1 < 6; p1++)
        //     {
        //         long prev = dp[i - 1, p1];
        //         if (prev == long.MaxValue) continue;

        //         for (int p2 = 0; p2 < 6; p2++)
        //         {
        //             if (!can[p1, p2]) continue;
        //             int x = qwe[p2][0];
        //             int y = qwe[p2][1];
        //             long costPair = cost[i][x] + cost[n - 1 - i][y];
        //             dp[i, p2] = Math.Min(dp[i, p2], prev + costPair);
        //         }
        //     }
        // }

        // long ans = long.MaxValue;
        // for (int p = 0; p < 6; p++)
        // {
        //     ans = Math.Min(ans, dp[m - 1, p]);
        // }

        // return ans;

        // Solution 2
        long[,,] memo = new long[n / 2, 4, 4];
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                for (int k = 0; k <= 3; k++)
                {
                    memo[i, j, k] = -1;
                }
            }
        }

        long DP(int idx, int prev1, int prev2)
        {
            if (idx >= n / 2) return 0;
            if (memo[idx, prev1, prev2] != -1) return memo[idx, prev1, prev2];
            long ans = long.MaxValue;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (i != j && i != prev1 && j != prev2)
                    {
                        ans = Math.Min(ans, cost[idx][i - 1] + cost[n - 1 - idx][j - 1] + DP(idx + 1, i, j));
                    }
                }
            }

            memo[idx, prev1, prev2] = ans;
            return ans;
        }

        return DP(0, 0, 0);
    }
}