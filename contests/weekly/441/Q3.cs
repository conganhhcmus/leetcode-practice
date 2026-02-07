public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        int n = nums.Length, ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0) continue;
            int k = MinKAction(queries, nums[i], i);
            if (k == -1) return -1;
            ans = Math.Max(ans, k);
        }
        return ans;
    }

    int MinKAction(int[][] queries, int num, int index)
    {
        List<int[]> vals = [];
        for (int i = 0; i < queries.Length; i++)
        {
            int l = queries[i][0], r = queries[i][1], val = queries[i][2];
            if (l <= index && index <= r)
            {
                vals.Add([val, i + 1]);
            }
        }
        int n = vals.Count;
        bool[,] dp = new bool[n + 1, num + 1];
        for (int i = 0; i <= n; i++) dp[i, 0] = true;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= num; j++)
            {
                if (vals[i - 1][0] > j)
                {
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    dp[i, j] = dp[i - 1, j] || dp[i - 1, j - vals[i - 1][0]];
                }
            }
            if (dp[i, num]) return vals[i - 1][1];
        }

        return -1;
    }
}