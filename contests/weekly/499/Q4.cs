
public class Solution
{
    const long INF = 1L << 60;

    class SegmentTree
    {
        int n;
        long[] tree;

        public SegmentTree(int size)
        {
            n = size;
            tree = new long[4 * n];

            for (int i = 0; i < tree.Length; i++)
                tree[i] = -INF;
        }

        public void Update(int idx, long val)
        {
            Update(1, 1, n, idx, val);
        }

        void Update(int node, int l, int r, int idx, long val)
        {
            if (l == r)
            {
                tree[node] = Math.Max(tree[node], val);
                return;
            }

            int mid = (l + r) / 2;

            if (idx <= mid)
                Update(node * 2, l, mid, idx, val);
            else
                Update(node * 2 + 1, mid + 1, r, idx, val);

            tree[node] = Math.Max(tree[node * 2], tree[node * 2 + 1]);
        }

        public long Query(int L, int R)
        {
            if (L > R) return -INF;
            return Query(1, 1, n, L, R);
        }

        long Query(int node, int l, int r, int L, int R)
        {
            if (R < l || r < L) return -INF;

            if (L <= l && r <= R)
                return tree[node];

            int mid = (l + r) / 2;

            return Math.Max(
                Query(node * 2, l, mid, L, R),
                Query(node * 2 + 1, mid + 1, r, L, R)
            );
        }
    }

    public long MaxAlternatingSum(int[] nums, int k)
    {
        // coordinate compression
        int[] vals = nums.Distinct().ToArray();
        Array.Sort(vals);

        Dictionary<int, int> rank = new();
        for (int i = 0; i < vals.Length; i++)
            rank[vals[i]] = i + 1; // 1-indexed rank

        int n = nums.Length;
        int m = vals.Length;

        SegmentTree treeUp = new(m);
        SegmentTree treeDown = new(m);

        long[] up = new long[n];
        long[] down = new long[n];

        long ans = -INF;

        for (int j = 0; j < n; j++)
        {
            int p = j - k;

            // activate valid predecessor
            if (p >= 0)
            {
                int rp = rank[nums[p]];

                treeUp.Update(rp, up[p]);
                treeDown.Update(rp, down[p]);
            }

            up[j] = nums[j];
            down[j] = nums[j];

            int r = rank[nums[j]];

            // nums[i] < nums[j]
            long bestSmall = treeDown.Query(1, r - 1);
            up[j] = Math.Max(up[j], bestSmall + nums[j]);

            // nums[i] > nums[j]
            long bestLarge = treeUp.Query(r + 1, m);
            down[j] = Math.Max(down[j], bestLarge + nums[j]);

            ans = Math.Max(ans, Math.Max(up[j], down[j]));
        }

        return ans;
    }
}

