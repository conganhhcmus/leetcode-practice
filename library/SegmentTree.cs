namespace Library;

public class SegmentTree
{
    readonly long[] data;
    readonly long[] tree;
    readonly long[] lazy;
    readonly int len;

    public SegmentTree(long[] nums)
    {
        len = nums.Length;
        data = new long[len];
        Array.Copy(nums, data, len);
        tree = new long[4 * len + 1];
        lazy = new long[4 * len + 1];
        Build(1, 0, len - 1);
    }

    public SegmentTree(int[] arr)
        : this(Array.ConvertAll(arr, x => (long)x)) { }

    // O(n * log n)
    private void Build(int node, int start, int end)
    {
        if (start == end)
        {
            tree[node] = data[start];
            return;
        }
        int mid = start + (end - start) / 2;
        Build(2 * node, start, mid);
        Build(2 * node + 1, mid + 1, end);
        PushUp(node);
    }

    // O(log n)
    public long Query(int st, int ed)
    {
        return Query(1, 0, len - 1, st, ed);
    }

    private long Query(int node, int start, int end, int qStart, int qEnd)
    {
        // if (end < qStart || start > qEnd) return int.MinValue; // return min value;
        if (end < qStart || start > qEnd)
            return 0; // return sum value = 0;
        if (qStart <= start && qEnd >= end)
            return tree[node];

        int mid = start + (end - start) / 2;
        PushDown(node);

        long ans = 0;
        if (qStart <= mid)
        {
            ans += Query(2 * node, start, mid, qStart, qEnd);
        }

        if (qEnd > mid)
        {
            ans += Query(2 * node + 1, mid + 1, end, qStart, qEnd);
        }

        return ans;
    }

    // O(log n)
    public void Update(int st, int ed, long val)
    {
        Update(1, 0, len - 1, st, ed, val);
    }

    private void Update(int node, int start, int end, int uStart, int uEnd, long value) // update increment or decrement value from l->r
    {
        if (uStart > end || uEnd < start)
            return;
        if (uStart <= start && uEnd >= end)
        {
            tree[node] += value * (end - start + 1);
            lazy[node] += value;
            return;
        }

        int mid = start + (end - start) / 2;
        PushDown(node);
        Update(2 * node, start, mid, uStart, uEnd, value);
        Update(2 * node + 1, mid + 1, end, uStart, uEnd, value);
        PushUp(node);
    }

    private void PushDown(int node)
    {
        if (lazy[node] != 0)
        {
            int mid = start + (end - start) / 2;
            tree[2 * node] += lazy[node] * (mid - start + 1);
            tree[2 * node + 1] += lazy[node] * (end - mid);
            lazy[2 * node] += lazy[node];
            lazy[2 * node + 1] += lazy[node];
            lazy[node] = 0;
        }
    }

    private void PushUp(int node)
    {
        tree[node] = tree[2 * node] + tree[2 * node + 1]; // sum value
    }
}


// SegmentTree for checked

// public class SegmentTree
// {
//     readonly long[] tree;
//     readonly long[] lazy;
//     readonly bool[] hasLazy;
//     readonly int n;
//
//     public SegmentTree(long[] arr)
//     {
//         n = arr.Length;
//         tree = new long[4 * n];
//         lazy = new long[4 * n];
//         hasLazy = new bool[4 * n];
//         Build(arr, 1, 0, n - 1);
//     }
//
//     public SegmentTree(int[] arr) : this(Array.ConvertAll(arr, x => (long)x)) { }
//
//     long GCD(long a, long b)
//     {
//         if (b == 0) return a;
//         return GCD(b, a % b);
//     }
//
//     void Build(long[] arr, int node, int l, int r)
//     {
//         if (l == r)
//         {
//             tree[node] = arr[l];
//             return;
//         }
//         int mid = (l + r) / 2;
//         Build(arr, node * 2, l, mid);
//         Build(arr, node * 2 + 1, mid + 1, r);
//         tree[node] = GCD(tree[node * 2], tree[node * 2 + 1]);
//     }
//
//     public long Query(int L, int R)
//     {
//         return Query(1, 0, n - 1, L, R);
//     }
//
//     long Query(int node, int l, int r, int L, int R)
//     {
//         if (R < l || r < L) return 0;
//         if (L <= l && r <= R) return tree[node];
//
//         PushDown(node);
//
//         int mid = (l + r) / 2;
//         long left = Query(node * 2, l, mid, L, R);
//         long right = Query(node * 2 + 1, mid + 1, r, L, R);
//         return GCD(left, right);
//     }
//
//     public void Update(int L, int R, long val)
//     {
//         Update(1, 0, n - 1, L, R, val);
//     }
//
//     void Update(int node, int l, int r, int L, int R, long val)
//     {
//         if (R < l || r < L) return;
//
//         if (L <= l && r <= R)
//         {
//             tree[node] = val;
//             lazy[node] = val;
//             hasLazy[node] = true;
//             return;
//         }
//
//         PushDown(node);
//
//         int mid = (l + r) / 2;
//         Update(node * 2, l, mid, L, R, val);
//         Update(node * 2 + 1, mid + 1, r, L, R, val);
//
//         PushUp(node);
//     }
//
//     void PushDown(int node)
//     {
//         if (!hasLazy[node]) return;
//
//         // push assignment to children
//         tree[node * 2] = lazy[node];
//         tree[node * 2 + 1] = lazy[node];
//
//         lazy[node * 2] = lazy[node];
//         lazy[node * 2 + 1] = lazy[node];
//
//         hasLazy[node * 2] = true;
//         hasLazy[node * 2 + 1] = true;
//
//         hasLazy[node] = false;
//     }
//
//     long PushUp(int node){
//         tree[node] = GCD(tree[2*node], tree[2*node+1]);
//         return tree[node];
//     }
// }
