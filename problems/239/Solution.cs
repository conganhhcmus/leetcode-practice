public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int n = nums.Length;
        int[] segTree = new int[4 * n];
        Build(segTree, nums, 0, n - 1, 1);
        int len = n - k + 1;
        int[] ret = new int[len];
        for (int i = 0; i < len; i++)
        {
            ret[i] = Max(segTree, 0, n - 1, 1, i, i + k - 1);
        }
        return ret;
    }

    void Build(int[] segTree, int[] nums, int start, int end, int node)
    {
        if (start == end)
        {
            segTree[node] = nums[start];
            return;
        }

        int mid = start + (end - start) / 2;
        Build(segTree, nums, start, mid, 2 * node);
        Build(segTree, nums, mid + 1, end, 2 * node + 1);
        PushUp(segTree, node);
    }

    int Max(int[] segTree, int start, int end, int node, int qStart, int qEnd)
    {
        if (qStart > end || qEnd < start) return int.MinValue;
        if (qStart <= start && qEnd >= end) return segTree[node];
        int mid = start + (end - start) / 2;
        int left = Max(segTree, start, mid, 2 * node, qStart, qEnd);
        int right = Max(segTree, mid + 1, end, 2 * node + 1, qStart, qEnd);
        return Math.Max(left, right);
    }

    void PushUp(int[] segTree, int node)
    {
        segTree[node] = Math.Max(segTree[2 * node], segTree[2 * node + 1]);
    }
}