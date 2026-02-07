public class Solution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        long ret = 0;
        int n = nums.Length;
        SegmentTree segTree = new(nums);
        List<int> idxExclude = [];
        for (int i = 0; i < n; ++i)
        {
            if (nums[i] > maxK || nums[i] < minK)
            {
                idxExclude.Add(i);
            }
        }
        int prev = 0;
        foreach (int idx in idxExclude)
        {
            ret += Count(segTree, minK, maxK, prev, idx - 1);
            prev = idx + 1;
        }

        ret += Count(segTree, minK, maxK, prev, n - 1);

        return ret;
    }

    long Count(SegmentTree segTree, int minK, int maxK, int start, int end)
    {
        if (start > end) return 0;
        long ret = 0;
        int l = start;
        for (int r = start; r <= end; ++r)
        {
            Node node = segTree.Query(l, r);
            while (node.Min == minK && node.Max == maxK)
            {
                l++;
                node = segTree.Query(l, r);
            }
            ret += l - start;
        }
        return ret;
    }
}


public class Node
{
    public int Min { get; set; } = int.MaxValue;
    public int Max { get; set; } = int.MinValue;
}

public class SegmentTree
{
    Node[] tree;
    int len;
    public SegmentTree(int[] arr)
    {
        len = arr.Length;
        tree = new Node[4 * len + 1];
        Build(arr, 1, 0, len - 1);
    }

    void Build(int[] arr, int node, int start, int end)
    {
        if (start == end)
        {
            Node tmp = new();
            tmp.Min = Math.Min(tmp.Min, arr[start]);
            tmp.Max = Math.Max(tmp.Max, arr[start]);
            tree[node] = tmp;
            return;
        }
        int mid = start + (end - start) / 2;
        Build(arr, 2 * node, start, mid);
        Build(arr, 2 * node + 1, mid + 1, end);
        PushUp(node);
    }

    void PushUp(int node)
    {
        Node tmp = new();
        tmp.Min = Math.Min(tree[2 * node].Min, tree[2 * node + 1].Min);
        tmp.Max = Math.Max(tree[2 * node].Max, tree[2 * node + 1].Max);
        tree[node] = tmp;
    }

    public Node Query(int start, int end)
    {
        return Query(1, 0, len - 1, start, end);
    }

    Node Query(int node, int start, int end, int qStart, int qEnd)
    {
        if (end < qStart || start > qEnd) return new Node();
        if (qStart <= start && qEnd >= end) return tree[node];

        int mid = start + (end - start) / 2;
        Node left = Query(2 * node, start, mid, qStart, qEnd);
        Node right = Query(2 * node + 1, mid + 1, end, qStart, qEnd);
        Node ret = new();
        ret.Min = Math.Min(left.Min, right.Min);
        ret.Max = Math.Max(left.Max, right.Max);
        return ret;
    }
}