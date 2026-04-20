public class Solution
{
    long[] prefix;
    long INF = long.MaxValue / 2;
    public long MinPartitionScore(int[] nums, int k)
    {
        int n = nums.Length;
        prefix = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            prefix[i] = prefix[i - 1] + nums[i - 1];
        }

        long Score(int i, int j)
        {
            long sum = prefix[i + 1] - prefix[j];
            return sum * (sum + 1) / 2L;
        }

        long[] dp = new long[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = Score(i, 0);
        }
        long[] ndp = new long[n];
        for (int t = 1; t < k; t++)
        {
            Array.Fill(ndp, INF);
            // dp[i] = dp[j] + score [j..i]
            for (int i = t; i < n; i++)
            {
                for (int j = t; j <= i; j++)
                {
                    ndp[i] = Math.Min(ndp[i], dp[j - 1] + Score(i, j));
                }
            }
            (dp, ndp) = (ndp, dp);
        }
        return dp[n - 1];
    }
}
