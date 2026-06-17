public class Solution
{
    public long MinInversionCount(int[] nums, int k)
    {
        int n = nums.Length;
        int[] vals = nums.ToHashSet().ToArray();
        Array.Sort(vals);
        int m = vals.Length;
        int[] rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            rank[i] = Array.BinarySearch(vals, nums[i]) + 1;
        }

        Fenwick bit = new(m);
        long cur = 0;
        for (int i = 0; i < k; i++)
        {
            // count greater rank[i] for i
            // cnt[i] = i - lessOrEqual[rank[i]]
            cur += i - bit.Query(rank[i]);
            bit.Add(rank[i], 1);
        }
        long ans = cur;
        for (int i = k; i < n; i++)
        {
            bit.Add(rank[i - k], -1);
            cur -= bit.Query(rank[i - k] - 1);
            cur += k - 1 - bit.Query(rank[i]);
            bit.Add(rank[i], 1);
            ans = Math.Min(ans, cur);
        }
        return ans;
    }

    class Fenwick
    {
        long[] tree;
        int n;
        public Fenwick(int n)
        {
            this.n = n;
            tree = new long[n + 1];
        }
        public void Add(int idx, long delta)
        {
            while (idx <= n)
            {
                tree[idx] += delta;
                idx += idx & -idx;
            }
        }

        public long Query(int idx)
        {
            long res = 0;
            while (idx > 0)
            {
                res += tree[idx];
                idx -= idx & -idx;
            }
            return res;
        }
    }
}
