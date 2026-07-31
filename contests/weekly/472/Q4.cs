public class Solution
{
    long[] minV, maxV, lazyV;
    public int LongestBalanced(int[] nums)
    {
        int n = nums.Length;
        int[] c = new int[n];
        for (int i = 0; i < n; i++) c[i] = (nums[i] % 2 == 0) ? 1 : -1;
        int[] nextSame = new int[n];
        Array.Fill(nextSame, n);
        Dictionary<int, int> lastIndex = [];
        for (int i = 0; i < n; i++)
        {
            if (lastIndex.TryGetValue(nums[i], out int prevIndex)) nextSame[prevIndex] = i;
            lastIndex[nums[i]] = i;
        }

        int treeSize = 4 * n;
        minV = new long[treeSize];
        maxV = new long[treeSize];
        lazyV = new long[treeSize];
        int ans = 0;
        for (int l = n - 1; l >= 0; l--)
        {
            RangeAdd(1, 0, n - 1, l, n - 1, c[l]);
            int ns = nextSame[l];
            if (ns < n) RangeAdd(1, 0, n - 1, ns, n - 1, -c[ns]);
            int r = QueryRightmostZero(1, 0, n - 1, l, n - 1);
            if (r != -1) ans = Math.Max(ans, r - l + 1);
        }

        return ans;
    }

    void Push(int node)
    {
        if (lazyV[node] != 0)
        {
            int lc = node * 2, rc = node * 2 + 1;
            minV[lc] += lazyV[node];
            maxV[lc] += lazyV[node];
            lazyV[lc] += lazyV[node];

            minV[rc] += lazyV[node];
            maxV[rc] += lazyV[node];
            lazyV[rc] += lazyV[node];

            lazyV[node] = 0;
        }
    }

    void RangeAdd(int node, int nodeL, int nodeR, int l, int r, int delta)
    {
        if (r < nodeL || nodeR < l) return;
        if (l <= nodeL && nodeR <= r)
        {
            minV[node] += delta;
            maxV[node] += delta;
            lazyV[node] += delta;
            return;
        }

        int mid = (nodeL + nodeR) / 2;
        Push(node);
        RangeAdd(node * 2, nodeL, mid, l, r, delta);
        RangeAdd(node * 2 + 1, mid + 1, nodeR, l, r, delta);
        minV[node] = Math.Min(minV[node * 2], minV[node * 2 + 1]);
        maxV[node] = Math.Max(maxV[node * 2], maxV[node * 2 + 1]);
    }

    int QueryRightmostZero(int node, int nodeL, int nodeR, int l, int r)
    {
        if (r < nodeL || nodeR < l || minV[node] > 0 || maxV[node] < 0) return -1;
        if (nodeL == nodeR) return nodeL;
        int mid = (nodeL + nodeR) / 2;
        Push(node);

        int rightRes = -1;
        if (r > mid) rightRes = QueryRightmostZero(node * 2 + 1, mid + 1, nodeR, l, r);
        if (rightRes != -1) return rightRes;
        if (l <= mid) return QueryRightmostZero(node * 2, nodeL, mid, l, r);
        return -1;
    }
}
