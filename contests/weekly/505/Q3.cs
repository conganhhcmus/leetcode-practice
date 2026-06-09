public class Solution
{
    public long MaximumSum(int[] nums, int m, int l, int r)
    {
        int n = nums.Length;
        long INF = 1L << 60;
        long[] prefSum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefSum[i + 1] = prefSum[i] + nums[i];
        }

        long[][] dp = new long[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new long[m + 1];
            Array.Fill(dp[i], -INF);
            dp[i][0] = 0L;
        }

        for (int j = 1; j <= m; j++)
        {
            LinkedList<int> dq = new();
            for (int i = 1; i <= n; i++)
            {
                dp[i][j] = dp[i - 1][j];
                int add = i - l;
                if (add >= 0)
                {
                    long val = dp[add][j - 1] - prefSum[add];
                    while (dq.Count > 0)
                    {
                        int back = dq.Last.Value;
                        long backVal = dp[back][j - 1] - prefSum[back];
                        if (backVal >= val) break;
                        dq.RemoveLast();
                    }
                    dq.AddLast(add);
                }
                while (dq.Count > 0 && dq.First.Value < i - r)
                {
                    dq.RemoveFirst();
                }
                if (dq.Count > 0)
                {
                    int x = dq.First.Value;
                    dp[i][j] = Math.Max(dp[i][j], prefSum[i] + dp[x][j - 1] - prefSum[x]);
                }
            }
        }

        long ans = -INF;
        for (int i = 1; i <= m; i++)
        {
            ans = Math.Max(ans, dp[n][i]);
        }
        return ans;
    }
}
