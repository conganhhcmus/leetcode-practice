public class Solution
{
    public long MostPoints(int[][] questions)
    {
        int n = questions.Length;
        long[] dp = new long[n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            int shift = Math.Min(i + questions[i][1] + 1, n);
            dp[i] = Math.Max(dp[i + 1], dp[shift] + questions[i][0]);
        }
        return dp[0];
    }
}