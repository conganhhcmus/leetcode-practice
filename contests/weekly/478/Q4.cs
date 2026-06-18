public class Solution
{
    public long[] MinOperations(int[] nums, int k, int[][] queries)
    {
        int n = nums.Length, m = queries.Length;
        // nums[i] = x * k + y
        // find t so sum of abs(x - t) is minimize
        int[] x = new int[n];
        int[] y = new int[n];
        for (int i = 0; i < n; i++)
        {
            int rem = ((nums[i] % k) + k) % k;
            y[i] = rem;
            x[i] = (nums[i] - rem) / k;
        }
        SegmentTree modTree = new(y);
        int[] vals = [.. x.Distinct()];
        Array.Sort(vals);
        int[] rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            rank[i] = Array.BinarySearch(vals, x[i]);
        }

        PersistentSegTree pst = new(rank, vals);

        long[] ans = new long[m];
        for (int i = 0; i < m; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            if (modTree.QueryMax(l, r) != modTree.QueryMin(l, r)) ans[i] = -1;
            else
            {
                int len = r - l + 1;
                int kth = (len + 1) >> 1;
                int median = pst.Kth(l, r, kth);
                var (cnt, sum) = pst.QueryLessEqual(l, r, median);
                long leftCnt = cnt;
                long leftSum = sum;
                long totCnt = len;
                long totSum = pst.RangeSum(l, r);

                long rightCnt = totCnt - leftCnt;
                long rightSum = totSum - leftSum;
                long cost = 1L * median * leftCnt - leftSum + rightSum - 1L * median * rightCnt;
                ans[i] = cost;
            }
        }
        return ans;
    }

    class SegmentTree
    {
        int[] minTree;
        int[] maxTree;
        long[] sumTree;
        int n;
        public SegmentTree(int[] nums)
        {
            n = nums.Length;
            minTree = new int[4 * n];
            maxTree = new int[4 * n];
            sumTree = new long[4 * n];
            Build(1, 0, n - 1, nums);
        }

        void Build(int node, int l, int r, int[] nums)
        {
            if (l == r)
            {
                minTree[node] = nums[l];
                maxTree[node] = nums[l];
                sumTree[node] = nums[l];
                return;
            }
            int m = (l + r) >> 1;
            Build(node << 1, l, m, nums);
            Build(node << 1 | 1, m + 1, r, nums);
            PushUp(node);
        }

        void PushUp(int node)
        {
            minTree[node] = Math.Min(minTree[node << 1], minTree[node << 1 | 1]);
            maxTree[node] = Math.Max(maxTree[node << 1], maxTree[node << 1 | 1]);
            sumTree[node] = sumTree[node << 1] + sumTree[node << 1 | 1];
        }

        int QueryMin(int node, int l, int r, int ql, int qr)
        {
            if (ql > r || qr < l) return int.MaxValue;
            if (ql <= l && qr >= r) return minTree[node];

            int m = (l + r) >> 1;
            int minL = QueryMin(node << 1, l, m, ql, qr);
            int minR = QueryMin(node << 1 | 1, m + 1, r, ql, qr);
            return Math.Min(minL, minR);
        }

        public int QueryMin(int ql, int qr) => QueryMin(1, 0, n - 1, ql, qr);

        int QueryMax(int node, int l, int r, int ql, int qr)
        {
            if (ql > r || qr < l) return int.MinValue;
            if (ql <= l && qr >= r) return maxTree[node];

            int m = (l + r) >> 1;
            int maxL = QueryMax(node << 1, l, m, ql, qr);
            int maxR = QueryMax(node << 1 | 1, m + 1, r, ql, qr);
            return Math.Max(maxL, maxR);
        }

        public int QueryMax(int ql, int qr) => QueryMax(1, 0, n - 1, ql, qr);

        long QuerySum(int node, int l, int r, int ql, int qr)
        {
            if (ql > r || qr < l) return 0L;
            if (ql <= l && qr >= r) return sumTree[node];

            int m = (l + r) >> 1;
            long sumL = QuerySum(node << 1, l, m, ql, qr);
            long sumR = QuerySum(node << 1 | 1, m + 1, r, ql, qr);
            return sumL + sumR;
        }

        public long QuerySum(int ql, int qr) => QuerySum(1, 0, n - 1, ql, qr);
    }

    class PersistentSegTree
    {
        class Node
        {
            public Node L;
            public Node R;
            public int Cnt;
            public long Sum;
        }

        Node[] roots;
        int[] values;
        int m;

        public PersistentSegTree(int[] rank, int[] values)
        {
            this.values = values;
            m = values.Length;

            int n = rank.Length;
            roots = new Node[n + 1];

            roots[0] = Build(0, m - 1);

            for (int i = 0; i < n; i++)
            {
                roots[i + 1] = Update(
                    roots[i],
                    0,
                    m - 1,
                    rank[i],
                    values[rank[i]]
                );
            }
        }

        Node Build(int l, int r)
        {
            Node node = new();

            if (l != r)
            {
                int mid = (l + r) >> 1;
                node.L = Build(l, mid);
                node.R = Build(mid + 1, r);
            }

            return node;
        }

        Node Update(Node prev, int l, int r, int pos, int value)
        {
            Node cur = new()
            {
                Cnt = prev.Cnt + 1,
                Sum = prev.Sum + value
            };

            if (l == r)
                return cur;

            int mid = (l + r) >> 1;

            if (pos <= mid)
            {
                cur.L = Update(prev.L, l, mid, pos, value);
                cur.R = prev.R;
            }
            else
            {
                cur.L = prev.L;
                cur.R = Update(prev.R, mid + 1, r, pos, value);
            }

            return cur;
        }

        public int Kth(int l, int r, int k)
        {
            int idx = Kth(
                roots[l],
                roots[r + 1],
                0,
                m - 1,
                k
            );

            return values[idx];
        }

        int Kth(Node leftRoot, Node rightRoot,
                int l, int r, int k)
        {
            if (l == r)
                return l;

            int leftCount =
                rightRoot.L.Cnt - leftRoot.L.Cnt;

            int mid = (l + r) >> 1;

            if (k <= leftCount)
            {
                return Kth(
                    leftRoot.L,
                    rightRoot.L,
                    l,
                    mid,
                    k
                );
            }

            return Kth(
                leftRoot.R,
                rightRoot.R,
                mid + 1,
                r,
                k - leftCount
            );
        }

        public (long cnt, long sum) QueryLessEqual(
            int l,
            int r,
            int value)
        {
            int pos = UpperBound(values, value) - 1;

            if (pos < 0)
                return (0, 0);

            return Query(
                roots[l],
                roots[r + 1],
                0,
                m - 1,
                0,
                pos
            );
        }

        public long RangeSum(int l, int r)
        {
            return roots[r + 1].Sum - roots[l].Sum;
        }

        (long cnt, long sum) Query(
            Node leftRoot,
            Node rightRoot,
            int l,
            int r,
            int ql,
            int qr)
        {
            if (ql > r || qr < l)
                return (0, 0);

            if (ql <= l && r <= qr)
            {
                return (
                    rightRoot.Cnt - leftRoot.Cnt,
                    rightRoot.Sum - leftRoot.Sum
                );
            }

            int mid = (l + r) >> 1;

            var a = Query(
                leftRoot.L,
                rightRoot.L,
                l,
                mid,
                ql,
                qr
            );

            var b = Query(
                leftRoot.R,
                rightRoot.R,
                mid + 1,
                r,
                ql,
                qr
            );

            return (
                a.cnt + b.cnt,
                a.sum + b.sum
            );
        }

        int UpperBound(int[] arr, int x)
        {
            int l = 0;
            int r = arr.Length;

            while (l < r)
            {
                int mid = (l + r) >> 1;

                if (arr[mid] <= x)
                    l = mid + 1;
                else
                    r = mid;
            }

            return l;
        }
    }
}
