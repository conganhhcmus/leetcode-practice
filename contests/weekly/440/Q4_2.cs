#if DEBUG
namespace Weekly_440_Q4_2;
#endif

public class Solution
{
    public long MaxSubarrays(int n, int[][] conflictingPairs)
    {
        int m = conflictingPairs.Length;
        for (int i = 0; i < m; i++)
        {
            if (conflictingPairs[i][0] > conflictingPairs[i][1])
            {
                (conflictingPairs[i][1], conflictingPairs[i][0]) = (conflictingPairs[i][0], conflictingPairs[i][1]);
            }
        }

        Array.Sort(conflictingPairs, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });

        /*
        f[i] = lastIndex;
        sigma(f[i] - i + 1) for i in 1..n = sigma(f[i]) - n(n+1)/2 + n;
        find the way to compute sigma(f[i]) when performing
        */

        long[] segTree = new long[4 * (n + 1)];
        long[] f = new long[n + 1];
        Build(segTree, f, 0, n, 1, n + 1, 1);
        int j = m - 1;
        long max = 0;
        for (int i = n; i > 0; i--)
        {
            // update
            max = Math.Max(max, Sum(segTree, 0, n, 1, n + 1, 1));
            // rollback
        }
        return max - n * (n + 1L) / 2 + n;
    }

    void Build(long[] segTree, long[] f, int start, int end, int l, int r, int node)
    {
        if (end < l || start > r) return;
        if (l <= start && r >= end)
        {
            segTree[node] = f[start];
            return;
        }

        int mid = start + (end - start) / 2;
        Build(segTree, f, start, mid, l, r, 2 * node);
        Build(segTree, f, mid + 1, end, l, r, 2 * node + 1);
        segTree[node] = segTree[2 * node] + segTree[2 * node + 1];
    }

    void Update(int[] segTree, int start, int end, int l, int r, int node, int val)
    {
        if (l > end || r < start) return;
        if (l <= start && r >= end)
        {
            segTree[node] = Math.Min(segTree[node], val);
            return;
        }
        int mid = start + (end - start) / 2;
        segTree[node] = Math.Min(segTree[2 * node], segTree[2 * node + 1]);
        Update(segTree, start, mid, l, r, 2 * node, val);
        Update(segTree, mid + 1, end, l, r, 2 * node + 1, val);
    }

    long Sum(long[] segTree, int start, int end, int l, int r, int node)
    {
        if (l > end || r < start) return 0;
        if (l <= start && r >= end)
        {
            return segTree[node];
        }
        int mid = start + (end - start) / 2;
        long leftSum = Sum(segTree, start, mid, l, r, 2 * node);
        long rightSum = Sum(segTree, mid + 1, end, l, r, 2 * node + 1);
        return leftSum + rightSum;
    }
}