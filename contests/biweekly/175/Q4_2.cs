public class Solution
{
    public long MinPartitionScore(int[] nums, int k)
    {
        int n = nums.Length;
        long INF = 1L << 60;
        long[] p = new long[n + 1];
        for (int i = 0; i < n; i++) p[i + 1] = p[i] + nums[i];

        // Cost function: sum * (sum + 1) / 2
        long GetCost(int j, int i)
        {
            long s = p[i] - p[j];
            return s * (s + 1) / 2;
        }

        long[] dp = new long[n + 1];
        long[] ndp = new long[n + 1];

        // Base case: Partition into k = 1
        for (int i = 0; i <= n; i++)
        {
            dp[i] = (i == 0) ? INF : GetCost(0, i);
        }
        dp[0] = 0;

        // Recursive D&C Optimization function
        void Solve(int l, int r, int optL, int optR)
        {
            if (l > r) return;

            int m = (l + r) / 2;
            long bestVal = INF;
            int bestIdx = -1;

            // Search for the optimal split point for m in the range [optL, optR]
            // We must split at j < m.
            int searchStart = Math.Max(optL, 0);
            int searchEnd = Math.Min(optR, m - 1);

            for (int j = searchStart; j <= searchEnd; j++)
            {
                if (dp[j] == INF) continue;

                long currentVal = dp[j] + GetCost(j, m);
                if (currentVal < bestVal)
                {
                    bestVal = currentVal;
                    bestIdx = j;
                }
            }

            ndp[m] = bestVal;
            int opt = bestIdx;

            // Divide and Conquer: 
            // Indices to the left of m have optimal split points <= opt
            // Indices to the right of m have optimal split points >= opt
            if (l <= m - 1) Solve(l, m - 1, optL, opt);
            if (m + 1 <= r) Solve(m + 1, r, opt, optR);
        }

        // Iterate through partitions from 2 to k
        for (int t = 2; t <= k; t++)
        {
            Array.Fill(ndp, INF);
            // Valid range for m is [t, n] because we need at least t elements for t partitions
            Solve(1, n, 0, n - 1);

            (ndp, dp) = (dp, ndp);
        }

        return dp[n];
    }
}
