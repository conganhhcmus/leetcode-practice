public class Solution
{
    public long MostPoints(int[][] questions)
    {
        int n = questions.Length;
        long[] memo = new long[n];
        Array.Fill(memo, -1);

        return DP(questions, 0, n, memo);
    }
    long DP(int[][] questions, int pos, int n, long[] memo)
    {
        if (pos >= n) return 0;
        if (memo[pos] != -1) return memo[pos];
        int point = questions[pos][0], skip = questions[pos][1];
        long ans = Math.Max(DP(questions, pos + 1, n, memo), point + DP(questions, pos + skip + 1, n, memo));
        memo[pos] = ans;
        return ans;
    }
}