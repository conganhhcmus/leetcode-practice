public class Solution
{
    class FenwickTree
    {
        int n;
        int[] tree;
        public FenwickTree(int n)
        {
            this.n = n;
            tree = new int[n];
        }

        public void Update(int idx, int val)
        {
            while (idx < n)
            {
                tree[idx] = Math.Max(tree[idx], val);
                idx += idx & -idx;
            }
        }

        public int Query(int idx)
        {
            int max = 0;
            while (idx > 0)
            {
                max = Math.Max(max, tree[idx]);
                idx -= idx & -idx;
            }
            return max;
        }
    }

    public int MaxFixedPoints(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, List<int>> groups = [];
        for (int i = 0; i < n; i++)
        {
            int v = nums[i];
            int g = i - v;
            if (g >= 0)
            {
                if (!groups.ContainsKey(v))
                {
                    groups[v] = [];
                }
                groups[v].Add(g);
            }
        }
        // dp[g] = max of dp[<=g] when v increase
        FenwickTree tree = new(n + 2);
        int ans = 0;
        for (int v = 0; v < n; v++)
        {
            List<(int g, int c)> updates = [];
            foreach (int g in groups.GetValueOrDefault(v, []))
            {
                int best = tree.Query(g + 1) + 1;
                updates.Add((g + 1, best));
                ans = Math.Max(ans, best);
            }

            foreach (var (idx, val) in updates)
            {
                tree.Update(idx, val);
            }
        }
        return ans;
    }
}
