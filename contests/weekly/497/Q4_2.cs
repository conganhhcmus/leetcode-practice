public class Solution
{
    public int CountGoodSubseq(int[] nums, int p, int[][] queries)
    {
        int n = nums.Length;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % p == 0)
            {
                nums[i] /= p;
                count++;
            }
            else
            {
                nums[i] = 0;
            }
        }
        SegmentTree tree = new(nums);
        int ans = 0;
        foreach (int[] q in queries)
        {
            int idx = q[0],
                val = q[1];
            if (nums[idx] != 0)
                count--;
            if (val % p == 0)
            {
                val /= p;
                count++;
            }
            else
                val = 0;
            nums[idx] = val;
            tree.Update(idx, idx, val);
            long gcd = tree.Query(0, n - 1);
            if (gcd != 1)
                continue;
            if (count < n || n > 30 || CanDropOne(nums))
            {
                ans++;
            }
        }
        return ans;
    }

    static long GCD(long a, long b)
    {
        if (b == 0)
            return a;
        return GCD(b, a % b);
    }

    bool CanDropOne(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1)
            return false;
        long[] prefix = new long[n];
        long[] suffix = new long[n];
        prefix[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            prefix[i] = GCD(prefix[i - 1], nums[i]);
        }

        suffix[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suffix[i] = GCD(suffix[i + 1], nums[i]);
        }
        for (int i = 0; i < n; i++)
        {
            long l = (i > 0) ? prefix[i - 1] : 0;
            long r = (i + 1 < n) ? suffix[i + 1] : 0;
            if (GCD(l, r) == 1)
                return true;
        }
        return false;
    }

    public class SegmentTree
    {
        readonly long[] tree;
        readonly long[] lazy;
        readonly bool[] hasLazy;
        readonly int n;

        public SegmentTree(long[] arr)
        {
            n = arr.Length;
            tree = new long[4 * n];
            lazy = new long[4 * n];
            hasLazy = new bool[4 * n];
            Build(arr, 1, 0, n - 1);
        }

        public SegmentTree(int[] arr)
            : this(Array.ConvertAll(arr, x => (long)x)) { }

        void Build(long[] arr, int node, int l, int r)
        {
            if (l == r)
            {
                tree[node] = arr[l];
                return;
            }
            int mid = (l + r) / 2;
            Build(arr, node * 2, l, mid);
            Build(arr, node * 2 + 1, mid + 1, r);
            tree[node] = GCD(tree[node * 2], tree[node * 2 + 1]);
        }

        public long Query(int L, int R)
        {
            return Query(1, 0, n - 1, L, R);
        }

        long Query(int node, int l, int r, int L, int R)
        {
            if (R < l || r < L)
                return 0;
            if (L <= l && r <= R)
                return tree[node];

            PushDown(node);

            int mid = (l + r) / 2;
            long left = Query(node * 2, l, mid, L, R);
            long right = Query(node * 2 + 1, mid + 1, r, L, R);
            return GCD(left, right);
        }

        public void Update(int L, int R, long val)
        {
            Update(1, 0, n - 1, L, R, val);
        }

        void Update(int node, int l, int r, int L, int R, long val)
        {
            if (R < l || r < L)
                return;

            if (L <= l && r <= R)
            {
                tree[node] = val;
                lazy[node] = val;
                hasLazy[node] = true;
                return;
            }

            PushDown(node);

            int mid = (l + r) / 2;
            Update(node * 2, l, mid, L, R, val);
            Update(node * 2 + 1, mid + 1, r, L, R, val);

            PushUp(node);
        }

        void PushDown(int node)
        {
            if (!hasLazy[node])
                return;

            // push assignment to children
            tree[node * 2] = lazy[node];
            tree[node * 2 + 1] = lazy[node];

            lazy[node * 2] = lazy[node];
            lazy[node * 2 + 1] = lazy[node];

            hasLazy[node * 2] = true;
            hasLazy[node * 2 + 1] = true;

            hasLazy[node] = false;
        }

        long PushUp(int node)
        {
            tree[node] = GCD(tree[2 * node], tree[2 * node + 1]);
            return tree[node];
        }
    }
}
