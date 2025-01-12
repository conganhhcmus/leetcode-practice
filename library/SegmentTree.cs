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
        if (end < qStart || start > qEnd) return 0; // return sum value = 0;
        if (qStart <= start && qEnd >= end) return tree[node];

        int mid = start + (end - start) / 2;
        PushDown(node, start, end, mid);

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
        if (uStart > end || uEnd < start) return;
        if (uStart <= start && uEnd >= end)
        {
            tree[node] += value;
            lazy[node] = value;
            return;
        }

        int mid = start + (end - start) / 2;
        PushDown(node, start, end, mid);
        Update(2 * node, start, mid, uStart, uEnd, value);
        Update(2 * node + 1, mid + 1, end, uStart, uEnd, value);
        PushUp(node);
    }

    private void PushDown(int node, int start, int end, int mid)
    {
        if (lazy[node] != 0)
        {
            tree[2 * node] += lazy[node];
            tree[2 * node + 1] += lazy[node];
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