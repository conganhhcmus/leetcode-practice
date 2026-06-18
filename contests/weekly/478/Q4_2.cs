public class Solution
{
    public long[] MinOperations(int[] nums, int k, int[][] queries)
    {
        int n = nums.Length;
        long[] arr = new long[n];
        int[] mod = new int[n];
        int[] reach = new int[n];
        int p = 0;
        for (int i = 0; i < n; i++)
        {
            mod[i] = nums[i] % k;
            arr[i] = nums[i] / k;
            while (p < n && (nums[i] - nums[p]) % k == 0) p++;
            reach[i] = p;
        }
        long[] pref = new long[n + 1];
        for (int i = 0; i < n; i++) pref[i + 1] = pref[i] + arr[i];
        int m = queries.Length;
        long[] ans = new long[m];
        long[] uniq = [.. arr.ToHashSet()];
        Array.Sort(uniq);
        SegTree tree = new(arr);
        for (int i = 0; i < m; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            if (reach[l] > r)
            {
                // m = median[l..r]
                // leftOpt = cntL * m - sumL
                // rightOpt = sumR - cntR * m
                // ans[i] = leftOpt + rightOpt
                int len = r - l + 1;
                int kthPos = (len + 1) / 2;
                long median = tree.Kth(l, r, kthPos, uniq);
                long cntLeft = tree.CountLE(1, 0, n - 1, l, r, median);
                long sumLeft = tree.SumLE(1, 0, n - 1, l, r, median);

                long totSum = pref[r + 1] - pref[l];
                long cntRight = len - cntLeft;
                long sumRight = totSum - sumLeft;
                long cost = median * cntLeft - sumLeft + sumRight - median * cntRight;
                ans[i] = cost;
            }
            else
            {
                ans[i] = -1;
            }
        }
        return ans;
    }
    class SegTree
    {
        class Node
        {
            public long[] vals;
            public long[] pref;
        }

        Node[] tree;
        int n;
        public SegTree(long[] nums)
        {
            n = nums.Length;
            tree = new Node[4 * n];
            for (int i = 0; i < 4 * n; i++)
            {
                tree[i] = new Node();
            }
            Build(1, 0, n - 1, nums);
        }

        void Build(int node, int l, int r, long[] nums)
        {
            if (l == r)
            {
                tree[node].vals = [nums[l]];
                tree[node].pref = [nums[l]];
                return;
            }

            int mid = (l + r) >> 1;
            Build(node << 1, l, mid, nums);
            Build(node << 1 | 1, mid + 1, r, nums);
            PushUp(node);
        }

        void PushUp(int node)
        {
            long[] a = tree[node << 1].vals;
            long[] b = tree[node << 1 | 1].vals;
            long[] merged = new long[a.Length + b.Length];
            int i = 0, j = 0, t = 0;
            while (i < a.Length && j < b.Length)
            {
                if (a[i] <= b[j]) merged[t++] = a[i++];
                else merged[t++] = b[j++];
            }
            while (i < a.Length) merged[t++] = a[i++];
            while (j < b.Length) merged[t++] = b[j++];
            long[] pref = new long[merged.Length];
            pref[0] = merged[0];
            for (int k = 1; k < merged.Length; k++) pref[k] = pref[k - 1] + merged[k];
            tree[node].vals = merged;
            tree[node].pref = pref;
        }

        int UpperBound(long[] arr, long x)
        {
            int l = 0, r = arr.Length - 1, ans = arr.Length;
            while (l <= r)
            {
                int m = (l + r) >> 1;
                if (arr[m] > x)
                {
                    ans = m;
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            return ans;
        }

        public int CountLE(int node, int l, int r, int ql, int qr, long x)
        {
            if (ql <= l && r <= qr) return UpperBound(tree[node].vals, x);
            if (r < ql || l > qr) return 0;
            int mid = (l + r) >> 1;
            return CountLE(node << 1, l, mid, ql, qr, x) + CountLE(node << 1 | 1, mid + 1, r, ql, qr, x);
        }

        public long SumLE(int node, int l, int r, int ql, int qr, long x)
        {
            if (ql <= l && qr >= r)
            {
                int cnt = UpperBound(tree[node].vals, x);
                if (cnt == 0) return 0;
                return tree[node].pref[cnt - 1];
            }
            if (r < ql || l > qr) return 0;
            int mid = (l + r) >> 1;
            return SumLE(node << 1, l, mid, ql, qr, x) + SumLE(node << 1 | 1, mid + 1, r, ql, qr, x);
        }

        public long Kth(int l, int r, int k, long[] uniq)
        {
            int lo = 0, hi = uniq.Length - 1, ans = 0;
            while (lo <= hi)
            {
                int mid = (lo + hi) >> 1;
                int cnt = CountLE(1, 0, n - 1, l, r, uniq[mid]);
                if (cnt >= k)
                {
                    ans = mid;
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return uniq[ans];
        }
    }
}
