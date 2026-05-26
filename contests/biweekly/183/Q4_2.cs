public class Solution
{
    public int CountValidSubsets(int[] parent, int[] nums, int k)
    {
        int n = parent.Length;
        int MOD = 1_000_000_007;
        long[][] dp0 = new long[n][];
        long[][] dp1 = new long[n][];
        for (int i = 0; i < n; i++)
        {
            dp0[i] = new long[k];
            dp1[i] = new long[k];
        }

        for (int i = 0; i < n; i++)
        {
            dp0[i][0] = dp1[i][nums[i] % k] = 1;
        }
        for (int i = n - 1; i > 0; i--)
        {
            int p = parent[i];
            long[] t = new long[k];
            for (int a = 0; a < k; a++)
            {
                t[a] = dp0[i][a] + dp1[i][a];
            }
            long[] n0 = new long[k];
            long[] n1 = new long[k];
            for (int x = 0; x < k; x++)
            {
                if (dp0[p][x] == 0 && dp1[p][x] == 0) continue;
                for (int y = 0; y < k; y++)
                {
                    int v = (x + y) % k;
                    n0[v] = (n0[v] + dp0[p][x] * t[y]) % MOD;
                    n1[v] = (n1[v] + dp1[p][x] * dp0[i][y]) % MOD;
                }
            }
            dp0[p] = n0;
            dp1[p] = n1;
        }

        return (int)((dp0[0][0] + dp1[0][0] - 1) % MOD);
    }
}
