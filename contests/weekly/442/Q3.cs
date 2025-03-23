#if DEBUG
namespace Weekly_442_Q3;
#endif

public class Solution
{
    public long MinTime(int[] skill, int[] mana)
    {
        int n = skill.Length, m = mana.Length;
        long[][] dp = new long[n + 1][];
        for (int i = 0; i <= n; i++) dp[i] = new long[m + 1];
        for (int j = 1; j <= m; j++)
        {
            for (int i = 1; i <= n; i++)
            {
                dp[i][j] = dp[i - 1][j] + 1L * skill[i - 1] * mana[j - 1];
            }
            long plus = 0;
            for (int i = 0; i < n; i++)
            {
                plus = Math.Max(plus, dp[i + 1][j - 1] - dp[i][j]);
            }

            for (int i = 0; i <= n; i++)
            {
                dp[i][j] += plus;
            }
        }
        return dp[n][m];
    }
}