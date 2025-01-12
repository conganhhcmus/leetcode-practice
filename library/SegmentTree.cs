namespace Library;

public class SegmentTree
{
    const int MAX = 100_000; // 10^5
    readonly int[] tree = new int[4 * MAX + 1];
    //readonly int[] lazy = new int[4 * MAX + 1];

    // O(n * log n)
    void Build(int[] nums, int node, int start, int end)
    {
        if (start == end)
        {
            tree[node] = nums[start];
            return;
        }
        int mid = start + (end - start) / 2;
        Build(nums, 2 * node, start, mid);
        Build(nums, 2 * node + 1, mid + 1, end);
        tree[node] = Math.Max(tree[2 * node], tree[2 * node + 1]); // max value
        //tree[node] = tree[2 * node] + tree[2 * node + 1]; // sum value
    }

    // O(log n)
    int Query(int node, int start, int end, int qStart, int qEnd)
    {
        if (end < qStart || start > qEnd) return int.MinValue; // return min value;
        //if (end < qStart || start > qEnd) return 0; // return sum value = 0;
        if (qStart <= start && qEnd >= end) return tree[node];

        int mid = start + (end - start) / 2;
        //PushLazy(node, start, end, mid);

        int left = Query(2 * node, start, mid, qStart, qEnd);
        int right = Query(2 * node + 1, mid + 1, end, qStart, qEnd);

        return Math.Max(left, right); // max value
        //return left + right; // sum value
    }

    // O(log n)
    void Update(int node, int start, int end, int pos, int value) // update increment or decrement value
    {
        if (pos < start || pos > end) return;
        if (start == end) // start == end == pos
        {
            tree[node] += value;
            return;
        }
        int mid = start + (end - start) / 2;
        if (pos <= mid) Update(2 * node, start, mid, pos, value);
        else Update(2 * node + 1, mid + 1, end, pos, value);

        tree[node] = Math.Max(tree[2 * node], tree[2 * node + 1]); // max value
        //tree[node] = tree[2 * node] + tree[2 * node + 1]; // sum value
    }

    // void Update(int node, int start, int end, int uStart, int uEnd, int value) // update increment or decrement value from l->r
    // {
    //     if (uStart > end || uEnd < start) return;
    //     if (uStart <= start && uEnd >= end)
    //     {
    //         tree[node] += value;
    //         lazy[node] += value;
    //         return;
    //     }

    //     int mid = start + (end - start) / 2;
    //     PushLazy(node, start, end, mid);
    //     Update(2 * node, start, mid, uStart, uEnd, value);
    //     Update(2 * node + 1, mid + 1, end, uStart, uEnd, value);

    //     tree[node] = Math.Max(tree[2 * node], tree[2 * node + 1]); // max value
    //     //tree[node] = tree[2 * node] + tree[2 * node + 1]; // sum value
    // }

    // void PushLazy(int node, int start, int end, int mid)
    // {
    //     if (lazy[node] != 0)
    //     {
    //         tree[2 * node] += lazy[node];
    //         tree[2 * node + 1] += lazy[node];
    //         lazy[2 * node] += lazy[node];
    //         lazy[2 * node + 1] += lazy[node];
    //         lazy[node] = 0;
    //     }
    // }
}