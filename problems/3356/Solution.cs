public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int[] segTree = new int[4 * n];
        Build(segTree, nums, 0, n - 1, 1);
        int m = queries.Length;
        int low = 0, high = m, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(segTree, queries, mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else low = mid + 1;
        }
        return ans;
    }
    bool Ok(int[] segTree, int[][] queries, int mid)
    {
        int n = segTree.Length / 4;
        int[] tmp = new int[4 * n];
        Array.Copy(segTree, tmp, 4 * n);
        int[] lazy = new int[4 * n];

        for (int i = 0; i < mid; i++)
        {
            int l = queries[i][0], r = queries[i][1], val = queries[i][2];
            Update(tmp, lazy, 0, n - 1, 1, l, r, -val);
        }

        return Query(tmp, lazy, 0, n - 1, 1) <= 0;
    }

    void Build(int[] segTree, int[] nums, int st, int ed, int node)
    {
        if (st == ed)
        {
            segTree[node] = nums[st];
            return;
        }
        int mid = st + (ed - st) / 2;
        Build(segTree, nums, st, mid, 2 * node);
        Build(segTree, nums, mid + 1, ed, 2 * node + 1);
        PushUp(segTree, node);
    }

    int Query(int[] segTree, int[] lazy, int st, int ed, int node)
    {
        if (st == ed) return segTree[node];
        int mid = st + (ed - st) / 2;
        PushDown(segTree, lazy, node);
        return Math.Max(Query(segTree, lazy, st, mid, 2 * node), Query(segTree, lazy, mid + 1, ed, 2 * node + 1));
    }

    void Update(int[] segTree, int[] lazy, int st, int ed, int node, int l, int r, int val)
    {
        if (l > ed || r < st) return;
        if (l <= st && r >= ed)
        {
            segTree[node] += val;
            lazy[node] += val;
            return;
        }
        int mid = st + (ed - st) / 2;
        PushDown(segTree, lazy, node);
        Update(segTree, lazy, st, mid, 2 * node, l, r, val);
        Update(segTree, lazy, mid + 1, ed, 2 * node + 1, l, r, val);
        PushUp(segTree, node);
    }

    void PushDown(int[] segTree, int[] lazy, int node)
    {
        if (lazy[node] != 0)
        {
            segTree[2 * node] += lazy[node];
            segTree[2 * node + 1] += lazy[node];
            lazy[2 * node] += lazy[node];
            lazy[2 * node + 1] += lazy[node];
            lazy[node] = 0;
        }
    }

    void PushUp(int[] segTree, int node)
    {
        segTree[node] = Math.Max(segTree[2 * node], segTree[2 * node + 1]);
    }
}