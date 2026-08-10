public class Solution
{
    public long WeightedSum(int[] parent, int[] nums)
    {
        int n = parent.Length;
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        for (int i = 1; i < n; i++)
        {
            g[parent[i]].Add(i);
        }
        int[] d = new int[n];
        d[0] = 1;
        Dfs(0);
        int h = 1;
        for (int i = 0; i < n; i++)
        {
            if (h < d[i]) h = d[i];
        }
        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans += 1L * nums[i] * (h - d[i] + 1);
        }
        return ans;

        void Dfs(int u)
        {
            foreach (int v in g[u])
            {
                d[v] = d[u] + 1;
                Dfs(v);
            }
        }
    }
}
