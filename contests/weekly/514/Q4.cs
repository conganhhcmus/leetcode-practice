public class Solution
{
    private int n = 0;
    private int[] nums = null!;
    private bool[] peak = null!;
    private Node[] tree = null!;

    public long[] CountOfPeaks(int[] nums, int[][] queries)
    {
        this.nums = nums;
        n = nums.Length;

        peak = new bool[n];

        // Build peak[]
        for (int i = 1; i < n - 1; i++)
        {
            peak[i] =
                nums[i] > nums[i - 1] &&
                nums[i] > nums[i + 1];
        }

        // Build segment tree
        tree = new Node[4 * n];

        Build(1, 0, n - 1);

        List<long> ans = [];

        foreach (var query in queries)
        {
            if (query[0] == 1)
            {
                ans.Add(CountQuery(query[1], query[2]));
            }
            else
            {
                UpdateValue(query[1], query[2]);
            }
        }

        return [.. ans];
    }

    // ============================================================
    // Query
    // ============================================================

    private long CountQuery(int l, int r)
    {
        if (r - l + 1 < 3) return 0;

        // Number of all subarrays with length >= 3.
        long total = CalcHeight(r - l + 1);

        // A peak must be strictly inside [l, r].
        Node node = Query(1, 0, n - 1, l + 1, r - 1);

        // No peak inside [l, r].
        if (node.First == -1) return 0;

        // Gap before the first peak.
        long leftGap = CalcHeight(node.First - l + 1);

        // Gaps between peaks.
        long internalGap = node.InTotal;

        // Gap after the last peak.
        long rightGap = CalcHeight(r - node.Last + 1);

        long nonPeak = leftGap + internalGap + rightGap;

        return total - nonPeak;
    }

    // ============================================================
    // Update nums[index]
    // ============================================================

    private void UpdateValue(int index, int value)
    {
        nums[index] = value;

        // Only index - 1, index, index + 1
        // can change their peak status.
        for (int i = Math.Max(1, index - 1); i <= Math.Min(n - 2, index + 1); i++)
        {
            bool newPeak = nums[i] > nums[i - 1] && nums[i] > nums[i + 1];
            if (newPeak == peak[i]) continue;
            peak[i] = newPeak;
            Update(1, 0, n - 1, i);
        }
    }

    // ============================================================
    // Node
    // ============================================================

    private class Node(
        int first = -1,
        int last = -1,
        long inTotal = 0)
    {
        public int First = first;
        public int Last = last;
        public long InTotal = inTotal;
    }

    // ============================================================
    // Merge
    // ============================================================

    private Node Merge(Node left, Node right)
    {
        // No peak in left.
        if (left.First == -1) return right;

        // No peak in right.
        if (right.First == -1) return left;

        // New gap created by joining the two nodes:
        //
        // left.Last -------- right.First
        //
        long newGap = CalcHeight(right.First - left.Last + 1);

        return new Node(left.First, right.Last, left.InTotal + right.InTotal + newGap);
    }

    // ============================================================
    // Build
    // ============================================================

    private void Build(int node, int left, int right)
    {
        if (left == right)
        {
            tree[node] = peak[left] ? new Node(left, left) : new Node();
            return;
        }

        int mid = left + (right - left) / 2;

        Build(node * 2, left, mid);

        Build(node * 2 + 1, mid + 1, right);

        tree[node] = Merge(tree[node * 2], tree[node * 2 + 1]);
    }

    // ============================================================
    // Query
    // ============================================================

    private Node Query(int node, int left, int right, int queryLeft, int queryRight)
    {
        // No intersection.
        if (queryRight < left || right < queryLeft)
        {
            return new Node();
        }

        // Completely inside.
        if (queryLeft <= left && right <= queryRight)
        {
            return tree[node];
        }

        int mid = left + (right - left) / 2;

        Node leftNode = Query(node * 2, left, mid, queryLeft, queryRight);

        Node rightNode = Query(node * 2 + 1, mid + 1, right, queryLeft, queryRight);

        return Merge(leftNode, rightNode);
    }

    // ============================================================
    // Update segment tree
    // ============================================================

    private void Update(int node, int left, int right, int index)
    {
        if (left == right)
        {
            tree[node] = peak[index] ? new Node(index, index) : new Node();
            return;
        }

        int mid = left + (right - left) / 2;

        if (index <= mid)
        {
            Update(node * 2, left, mid, index);
        }
        else
        {
            Update(node * 2 + 1, mid + 1, right, index);
        }

        tree[node] = Merge(tree[node * 2], tree[node * 2 + 1]);
    }

    // ============================================================
    // Helper
    // ============================================================

    private long CalcHeight(int length)
    {
        if (length < 3) return 0;

        return (long)(length - 1) * (length - 2) / 2;
    }
}
