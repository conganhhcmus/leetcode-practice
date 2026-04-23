public class Solution
{
    public long[] GetDistances(int[] arr)
    {
        int n = arr.Length;
        Dictionary<int, List<int>> group = [];
        for (int i = 0; i < n; i++)
        {
            int x = arr[i];
            if (!group.ContainsKey(x))
            {
                group[x] = [];
            }
            group[x].Add(i);
        }
        long[] ans = new long[n];
        foreach (List<int> g in group.Values)
        {
            long tot = 0;
            foreach (int idx in g)
            {
                tot += idx;
            }
            long pref = 0;
            int sz = g.Count;
            for (int i = 0; i < sz; i++)
            {
                ans[g[i]] = tot - 2 * pref + 1L * g[i] * (2 * i - sz);
                pref += g[i];
            }
        }
        return ans;
    }
}
