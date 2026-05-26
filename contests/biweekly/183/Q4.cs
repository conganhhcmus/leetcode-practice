public class Solution
{
    public int CountValidSubsets(int[] parent, int[] nums, int k)
    {
        int MOD = 1_000_000_007;
        int n = parent.Length;
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        for (int i = 1; i < n; i++) g[parent[i]].Add(i);
        var (root0, root1) = Dfs(0);
        return (int)((root0[0] + root1[0] - 1) % MOD);

        // dp0 : not select u
        // dp1: select u
        (long[], long[]) Dfs(int u)
        {
            long[] dp0 = new long[k];
            long[] dp1 = new long[k];
            dp0[0] = 1;
            dp1[nums[u] % k] = 1;
            foreach (int v in g[u])
            {
                var (child0, child1) = Dfs(v);
                long[] ndp0 = new long[k];
                long[] ndp1 = new long[k];
                for (int a = 0; a < k; a++)
                {
                    if (dp0[a] == 0) continue;
                    for (int b = 0; b < k; b++)
                    {
                        long ways = (child0[b] + child1[b]) % MOD;
                        int nr = (a + b) % k;
                        ndp0[nr] = (ndp0[nr] + dp0[a] * ways) % MOD;
                    }
                }

                for (int a = 0; a < k; a++)
                {
                    if (dp1[a] == 0) continue;
                    for (int b = 0; b < k; b++)
                    {
                        if (child0[b] == 0) continue;
                        int nr = (a + b) % k;
                        ndp1[nr] = (ndp1[nr] + dp1[a] * child0[b]) % MOD;
                    }
                }
                dp0 = ndp0;
                dp1 = ndp1;
            }
            return (dp0, dp1);
        }
    }
}
