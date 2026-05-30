namespace Library;

public class Treap
{
    private class Node
    {
        public int Val;
        public int Priority;
        public int Count;
        public Node Left;
        public Node Right;

        public Node(int val, int priority)
        {
            Val = val;
            Priority = priority;
            Count = 1;
        }
    }

    private Node root;
    private readonly Random rand = new(1);

    public int? LowerBound(int target)
    {
        Node cur = root;
        int? ans = null;
        while (cur != null)
        {
            if (cur.Val >= target)
            {
                ans = cur.Val;
                cur = cur.Left;
            }
            else
            {
                cur = cur.Right;
            }
        }
        return ans;
    }

    public int? UpperBound(int target)
    {
        Node cur = root;
        int? ans = null;

        while (cur != null)
        {
            if (cur.Val > target)
            {
                ans = cur.Val;
                cur = cur.Left;
            }
            else
            {
                cur = cur.Right;
            }
        }

        return ans;
    }

    public void Insert(int val)
    {
        root = Insert(root, val);
    }

    private Node Insert(Node node, int val)
    {
        if (node == null)
            return new Node(val, rand.Next());

        if (val == node.Val)
        {
            node.Count++;
            return node;
        }

        if (val < node.Val)
        {
            node.Left = Insert(node.Left, val);
            if (node.Left.Priority > node.Priority)
                node = RotateRight(node);
        }
        else
        {
            node.Right = Insert(node.Right, val);
            if (node.Right.Priority > node.Priority)
                node = RotateLeft(node);
        }

        return node;
    }

    public void Remove(int val)
    {
        root = Remove(root, val);
    }

    private Node Remove(Node node, int val)
    {
        if (node == null) return null;
        if (val < node.Val)
        {
            node.Left = Remove(node.Left, val);
        }
        else if (val > node.Val)
        {
            node.Right = Remove(node.Right, val);
        }
        else
        {
            // found it
            if (node.Count > 1)
            {
                node.Count--;
                return node;
            }
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;
            if (node.Left.Priority > node.Right.Priority)
            {
                node = RotateRight(node);
                node.Right = Remove(node.Right, val);
            }
            else
            {
                node = RotateLeft(node);
                node.Left = Remove(node.Left, val);
            }
        }
        return node;
    }

    private Node RotateRight(Node p)
    {
        Node q = p.Left;
        p.Left = q.Right;
        q.Right = p;
        return q;
    }

    private Node RotateLeft(Node p)
    {
        Node q = p.Right;
        p.Right = q.Left;
        q.Left = p;
        return q;
    }
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
