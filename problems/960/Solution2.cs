public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int n = strs.Length, m = strs[0].Length;
        int[] dp = new int[m];
        int best = 1;

        for (int j = 0; j < m; j++)
        {
            dp[j] = 1;
            for (int k = 0; k < j; k++)
            {
                bool ok = true;
                for (int i = 0; i < n; i++)
                {
                    if (strs[i][k] > strs[i][j])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok) dp[j] = Math.Max(dp[j], dp[k] + 1);
            }
            best = Math.Max(best, dp[j]);
        }

        return m - best;
    }
}