#if DEBUG
namespace Problems_474_2;
#endif

public class Solution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int[][] dp = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n + 1];
        }

        foreach (string str in strs)
        {
            int one = 0, zero = 0;
            foreach (char c in str)
            {
                if (c == '0') zero++;
                else one++;
            }
            for (int i = m; i >= zero; i--)
            {
                for (int j = n; j >= one; j--)
                {
                    dp[i][j] = Math.Max(dp[i][j], dp[i - zero][j - one] + 1);
                }
            }
        }

        return dp[m][n];
    }
}