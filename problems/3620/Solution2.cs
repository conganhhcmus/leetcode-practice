public class Solution
{
    public int FindMaxPathScore(int[][] edges, bool[] online, long k)
    {
        int n = online.Length;
        List<int[]>[] g = new List<int[]>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        int lo = int.MaxValue, hi = 0;
        foreach (int[] e in edges)
        {
            if (online[e[0]] && online[e[1]])
            {
                g[e[0]].Add([e[1], e[2]]);
                lo = Math.Min(lo, e[2]);
                hi = Math.Max(hi, e[2]);
            }
        }
        int ans = -1;
        long[] memo = new long[n];
        while (lo <= hi)
        {
            int mi = lo + (hi - lo) / 2;
            Array.Fill(memo, -1);
            if (Dfs(0, mi) <= k)
            {
                ans = mi;
                lo = mi + 1;
            }
            else
            {
                hi = mi - 1;
            }
        }
        return ans;

        long Dfs(int u, int x)
        {
            if (u == n - 1) return 0;
            if (memo[u] != -1) return memo[u];
            long res = long.MaxValue / 2;
            foreach (int[] nei in g[u])
            {
                int v = nei[0], c = nei[1];
                if (c >= x) res = Math.Min(res, Dfs(v, x) + c);
            }
            return memo[u] = res;
        }
    }
}
