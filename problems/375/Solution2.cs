#if DEBUG
namespace Problems_375_2;
#endif

public class Solution
{
    public int GetMoneyAmount(int n)
    {
        // dp[i][j] = money amount guarantee to find x in [i..j]
        // return dp[1][n]
        // dp[i][j] = min of x + Math.Max(dp[i][x-1],dp[x+1,j]) where x from i to j
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[n + 1];
        }

        for (int len = 2; len <= n; len++)
        {
            for (int st = 1; st <= n - len + 1; st++)
            {
                int min = int.MaxValue;
                for (int x = st; x <= st + len - 1; x++)
                {
                    min = Math.Min(min, x + Math.Max(dp[st][x - 1], dp[Math.Min(n, x + 1)][st + len - 1]));
                }
                dp[st][st + len - 1] = min;
            }
        }
        return dp[1][n];
    }
}