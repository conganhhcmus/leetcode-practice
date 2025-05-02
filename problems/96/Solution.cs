#if DEBUG
namespace Problems_96;
#endif

public class Solution
{
    public int NumTrees(int n)
    {
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[n + 1];
        }
        dp[0][0] = 0;
        for (int num = 1; num <= n; num++)
        {
            for (int start = 1; start <= n - num + 1; start++)
            {
                int end = start + num - 1;
                for (int i = start; i <= end; i++)
                {
                    int left = i != start ? dp[start][i - 1] : 1;
                    int right = i != end ? dp[i + 1][end] : 1;
                    dp[start][end] += Math.Max(1, left) * Math.Max(1, right);
                }
            }
        }

        return dp[1][n];
    }
}