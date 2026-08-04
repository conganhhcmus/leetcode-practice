public class Solution
{
    public long CountRatioSubarrays(int[] nums, int a, int b)
    {
        int n = nums.Length;
        // x / y <= a / b
        // x * b <= y * a
        // (x2 - x1) * b <= (y2 - y1) * a
        // x2 * b - x1 * b <= y2 * a - y1 * a
        // x2 * b - y2 * a <= x1 * b - y1 * a
        // for each i with x2, y2 find all j so x1, y1
        int cntO = 0, cntE = 0;
        long ans = 0;
        long shift = (long)1e16;
        DynamicSegmentTree tree = new();
        tree.Update(shift, 1);
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 0) cntE++;
            else cntO++;
            long val = 1L * cntO * a - 1L * cntE * b;
            ans += tree.Query(0, val + shift);

            tree.Update(val + shift, 1);
        }
        return ans;
    }

    class Node
    {
        public long Sum;
        public Node? Left;
        public Node? Right;
    }

    class DynamicSegmentTree
    {
        long MIN = 0;
        long MAX = (long)1e18;
        Node root = new();
        public void Update(long idx, long delta)
        {
            Update(root, MIN, MAX, idx, delta);
        }

        void Update(Node node, long l, long r, long idx, long delta)
        {
            if (l == r)
            {
                node.Sum += delta;
                return;
            }
            long mid = l + (r - l) / 2;
            if (idx <= mid)
            {
                node.Left ??= new Node();
                Update(node.Left, l, mid, idx, delta);
            }
            else
            {
                node.Right ??= new Node();
                Update(node.Right, mid + 1, r, idx, delta);
            }
            node.Sum = (node.Left?.Sum ?? 0) + (node.Right?.Sum ?? 0);
        }

        public long Query(long left, long right)
        {
            return Query(root, MIN, MAX, left, right);
        }

        long Query(Node? node, long l, long r, long ql, long qr)
        {
            if (node == null || qr < l || r < ql) return 0;
            if (ql <= l && r <= qr) return node.Sum;
            long mid = l + (r - l) / 2;
            return Query(node.Left, l, mid, ql, qr) + Query(node.Right, mid + 1, r, ql, qr);
        }
    }
}
