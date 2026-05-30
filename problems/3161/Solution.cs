public class Solution
{
    public IList<bool> GetResults(int[][] queries)
    {
        IList<bool> ans = [];
        ImplicitTreap treap = new();
        int INF = 1 << 30;
        List<int> blocks = [INF];
        treap.Insert(0, INF);
        foreach (int[] q in queries)
        {
            if (q[0] == 1)
            {
                int x = q[1];
                int idx = blocks.BinarySearch(x);
                if (idx < 0) idx = ~idx;
                int l = idx > 0 ? blocks[idx - 1] : 0;
                int r = blocks[idx];
                treap.Delete(idx);
                treap.Insert(idx, r - x);
                treap.Insert(idx, x - l);
                blocks.Insert(idx, x);
            }
            else
            {
                int x = q[1];
                int sz = q[2];
                int idx = blocks.BinarySearch(x);
                if (idx >= 0)
                {
                    ans.Add(treap.QueryMax(0, idx) >= sz);
                }
                else
                {
                    idx = ~idx;
                    if (idx > 0)
                    {
                        ans.Add(treap.QueryMax(0, idx - 1) >= sz || x - blocks[idx - 1] >= sz);
                    }
                    else
                    {
                        ans.Add(x >= sz);
                    }
                }
            }
        }
        return ans;
    }

    public class ImplicitTreap
    {
        class Node
        {
            public long Val;
            public long Sum;
            public long Min;
            public long Max;

            public int Size;
            public int Priority;

            public Node Left;
            public Node Right;

            public Node(long val)
            {
                Val = val;
                Sum = val;
                Min = val;
                Max = val;
                Size = 1;
                Priority = Random.Shared.Next();
            }
        }

        Node root;
        int Size(Node t) => t?.Size ?? 0;
        long Sum(Node t) => t?.Sum ?? 0;
        long Min(Node t) => t?.Min ?? long.MaxValue;
        long Max(Node t) => t?.Max ?? long.MinValue;
        int Count => Size(root);

        void Pull(Node t)
        {
            if (t == null) return;
            t.Size = 1 + Size(t.Left) + Size(t.Right);
            t.Sum = t.Val;
            t.Min = t.Val;
            t.Max = t.Val;

            if (t.Left != null)
            {
                t.Sum += t.Left.Sum;
                t.Min = Math.Min(t.Min, t.Left.Min);
                t.Max = Math.Max(t.Max, t.Left.Max);
            }

            if (t.Right != null)
            {
                t.Sum += t.Right.Sum;
                t.Min = Math.Min(t.Min, t.Right.Min);
                t.Max = Math.Max(t.Max, t.Right.Max);
            }
        }

        Node Merge(Node a, Node b)
        {
            if (a == null) return b;
            if (b == null) return a;
            if (a.Priority > b.Priority)
            {
                a.Right = Merge(a.Right, b);
                Pull(a);
                return a;
            }
            b.Left = Merge(a, b.Left);
            Pull(b);
            return b;
        }

        void Split(Node root, int k, out Node left, out Node right)
        {
            if (root == null)
            {
                left = null;
                right = null;
                return;
            }
            int leftSize = Size(root.Left);
            if (k <= leftSize)
            {
                Split(root.Left, k, out left, out Node temp);
                root.Left = temp;
                Pull(root);
                right = root;
            }
            else
            {
                Split(root.Right, k - leftSize - 1, out Node temp, out right);
                root.Right = temp;
                Pull(root);
                left = root;
            }
        }

        public void Insert(int pos, long val)
        {
            Split(root, pos, out Node a, out Node b);
            Node node = new(val);
            root = Merge(Merge(a, node), b);
        }

        public void Delete(int pos)
        {
            Split(root, pos, out Node a, out Node b);
            Split(b, 1, out _, out Node c);
            root = Merge(a, c);
        }

        public long QuerySum(int l, int r)
        {
            Split(root, l, out Node a, out Node b);
            Split(b, r - l + 1, out Node mid, out Node c);
            long ans = Sum(mid);
            root = Merge(a, Merge(mid, c));
            return ans;
        }

        public long QueryMax(int l, int r)
        {
            Split(root, l, out Node a, out Node b);
            Split(b, r - l + 1, out Node mid, out Node c);
            long ans = Max(mid);
            root = Merge(a, Merge(mid, c));
            return ans;
        }

        public long QueryMin(int l, int r)
        {
            Split(root, l, out Node a, out Node b);
            Split(b, r - l + 1, out Node mid, out Node c);
            long ans = Min(mid);
            root = Merge(a, Merge(mid, c));
            return ans;
        }

        public long Get(int idx)
        {
            Split(root, idx, out Node a, out Node b);
            Split(b, 1, out Node mid, out Node c);
            long ans = mid.Val;
            root = Merge(a, Merge(mid, c));
            return ans;
        }

        public void Set(int idx, long val)
        {
            Split(root, idx, out Node a, out Node b);
            Split(b, 1, out Node mid, out Node c);
            mid.Val = val;
            Pull(mid);
            root = Merge(a, Merge(mid, c));
        }
    }
}
